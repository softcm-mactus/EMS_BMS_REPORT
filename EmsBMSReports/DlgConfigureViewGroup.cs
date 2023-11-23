using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Windows.Forms;
using static MactusReportLib.MactusReportLib;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Xml.Linq;
using DataGridViewMultiColumnComboColumnDemo;

namespace EmsBMSReports
{
    public partial class DlgConfigureViewGroup
    {
        public class Column
        {
            public int id;
            public string name;
        }
        public class Group
        {
            public string name;
            public List<Column> columns = new List<Column>();
        }
        public class Category
        {
            public string name;
            public List<Group> groups = new List<Group>();
            public Dictionary<string, Group> groupMap = new Dictionary<string, Group>();
        }
        public class ColumnMetaData
        {
            public int id;
            public string _idName;
            public string name;
            public string source;
            public string _dropdown;
            public string idName
            {
                get { return _idName; }
                set { _idName = value; }
            }
            public string dropdown
            {
                get { return _dropdown; }
                set { _dropdown = value; }
            }
            public string getString()
            {
                string ToStringRet = default;
                ToStringRet = id.ToString() + "  -  " + name + "  :  " + source;
                return ToStringRet;
            }

        }
        public List<Category> categories = new List<Category>();
        public Dictionary<string, Category> categoriesMap = new Dictionary<string, Category>();
        public static Dictionary<int, ColumnMetaData> metaData = new Dictionary<int, ColumnMetaData>();
        public static List<ColumnMetaData> metaDataValues = new List<ColumnMetaData>();
        public static List<string> colIds = new List<string>();
        public DlgConfigureViewGroup()
        {
            InitializeComponent();
        }
        private void DataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var node = groupView.Nodes.Add("Category " + categories.Count.ToString());
            var c = new Category();
            c.name = node.Text;
            node.Tag = c;
            node.BeginEdit();
            categories.Add(c);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var parent = groupView.SelectedNode;
            if (parent != null)
            {
                if (parent.Parent != null)
                {
                    parent = parent.Parent;
                }
                if (parent.Tag != null & parent.Tag is Category)
                {
                    Category parentCategory = (Category)parent.Tag;
                    var node = parent.Nodes.Add("Group " + parentCategory.groups.Count.ToString());
                    var g = new Group();
                    g.name = node.Text;
                    node.Tag = g;
                    parentCategory.groups.Add(g);
                    parent.ExpandAll();
                    node.BeginEdit();
                }
            }

        }

        private void DlgConfigureViewGroup_Load(object sender, EventArgs e)
        {
            DataGridViewMultiColumnComboColumn newColumn
                = new DataGridViewMultiColumnComboColumn();
            newColumn.CellTemplate = new DataGridViewMultiColumnComboCell();
            newColumn.HeaderText = "ExternalLogId";
            newColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            newColumn.FlatStyle = FlatStyle.Flat;
            colGrid.Columns.Remove(colGrid.Columns[0]);
            colGrid.Columns.Insert(0, newColumn);
            colGrid.Columns[0].Width = 100;
            try
            {
                colIds.Clear();
                metaData.Clear();
                metaDataValues.Clear();
                string sQuery = "SELECT * FROM nsp.Trend_Meta order by ExternalLogId";
                var eConnection = new OdbcConnection(g_sEMSDbConString);
                eConnection.Open();
                var oCmd = new OdbcCommand(sQuery, eConnection);
                var oReader = oCmd.ExecuteReader();
                while (oReader.Read())
                {
                    var o = new ColumnMetaData();
                    o.id = int.Parse(Conversions.ToString(oReader["ExternalLogId"]));
                    try
                    {
                        o.source = Conversions.ToString(oReader["Source"]);
                        o.name = o.source.Split('/').Last();
                    }
                    catch (Exception )
                    {

                    }
                    o._idName = o.id.ToString();
                    o._dropdown = o.getString();
                    metaData.Add(o.id, o);
                    metaDataValues.Add(o);
                    colIds.Add(o.idName);
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message);
            }
            for (int i = 0; i < colGrid.RowCount; i++)
            {
                setExternalLogIds(i);
            }
            try
            {
                string sQuery = "SELECT * FROM TBL_ReportGroups order by CategoryName, GroupName, ExternalLogId";
                var oConnection = new OdbcConnection(g_sConString);
                oConnection.Open();
                var oCmd = new OdbcCommand(sQuery, oConnection);
                var oReader = oCmd.ExecuteReader();
                while (oReader.Read())
                {
                    var o = new Column();
                    o.id = int.Parse(Conversions.ToString(oReader["ExternalLogId"]));
                    o.name = Conversions.ToString(oReader["ColumnName"]);
                    Category cat;
                    Group group;
                    if (!categoriesMap.ContainsKey(Conversions.ToString(oReader["CategoryName"])))
                    {
                        cat = new Category();
                        cat.name = Conversions.ToString(oReader["CategoryName"]);
                        categoriesMap.Add(cat.name, cat);
                        categories.Add(cat);
                    }
                    else
                    {
                        cat = categoriesMap[Conversions.ToString(oReader["CategoryName"])];
                    }
                    if (!cat.groupMap.ContainsKey(Conversions.ToString(oReader["GroupName"])))
                    {
                        group = new Group();
                        group.name = Conversions.ToString(oReader["GroupName"]);
                        cat.groupMap.Add(group.name, group);
                        cat.groups.Add(group);
                    }
                    else
                    {
                        group = cat.groupMap[oReader["GroupName"].ToString()];
                    }
                    group.columns.Add(o);
                }
                bool isFirst = true;
                foreach (var c in categories)
                {
                    var n = groupView.Nodes.Add(c.name);
                    n.Tag = c;
                    if (isFirst)
                    {
                        groupView.SelectedNode = n;
                    }
                    foreach (var g in c.groups)
                    {
                        var n1 = n.Nodes.Add(g.name);
                        n1.Tag = g;
                        if (isFirst)
                        {
                            groupView.SelectedNode = n1;
                            populateColumGrid(g);
                        }
                        isFirst = false;
                    }
                    isFirst = false;
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message);
            }
        }

        private void populateColumGrid(Group g)
        {
            colGrid.Rows.Clear();
            foreach (var col in g.columns)
            {
                int r = colGrid.Rows.Add();
                colGrid.Rows[r].Tag = col;
                colGrid.Rows[r].Cells[0].Value = col.id.ToString();
                colGrid.Rows[r].Cells[1].Value = col.name;
                setExternalLogIds(r);
            }
        }

        private void setExternalLogIds(int i)
        {
            var cell = colGrid.Rows[i].Cells[0] as DataGridViewMultiColumnComboCell;
            cell.DropDownWidth = 700;
            cell.DataSource = colIds;
            cell.ValueType = typeof(string);
            //cell.DisplayMember = "dropdown";
            //cell.ValueMember = "idName";
        }

        private void addGroup_TextChanged(object sender, EventArgs e)
        {
            var parent = groupView.SelectedNode;
            if (parent != null)
            {
                if (parent.Tag != null & parent.Tag is Category)
                {
                    Category parentCategory = (Category)parent.Tag;
                    parentCategory.name = parent.Text;
                }
                else if (parent.Tag != null & parent.Tag is Group)
                {
                    Group parentGroup = (Group)parent.Tag;
                    parentGroup.name = parent.Text;
                }
            }
        }

        private void groupView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var parent = groupView.SelectedNode;
            if (parent != null)
            {
                if (parent.Tag != null & parent.Tag is Category)
                {
                    parent.BeginEdit();
                }
                else if (parent.Tag != null & parent.Tag is Group)
                {
                    parent.BeginEdit();
                }
            }
        }

        private void colGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                colGrid.EditMode = (DataGridViewEditMode)Conversions.ToInteger(true);
            }
            catch (Exception )
            {
            }
        }

        private void colGrid_TextChanged(object sender, EventArgs e)
        {
            for (int r = 0; r<colGrid.Rows.Count; r++)
            {
                try
                {
                    Column c = (Column)colGrid.Rows[r].Tag;
                    c.id = (colGrid.Rows[r].Cells[0].Value as ColumnMetaData).id;
                    c.name = Conversions.ToString(colGrid.Rows[r].Cells[1].Value);
                    if(c.name.Length ==0)
                    {
                        c.name = metaData[c.id].name;
                        colGrid.Rows[r].Cells[1].Value=c.name;
                    }
                }
                catch (Exception )
                {

                }
            }
        }

        private void colGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for(int i=e.RowIndex;i<e.RowIndex+e.RowCount;i++)
            {
                setExternalLogIds(i);
                //cell.Items.Clear();
                //foreach(var v in metaData.Values)
                //{
                //    var index = cell.Items.Add(v);
                //}
            }
        }

        private void DataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            {
                try
                {
                    var i = colGrid.Rows[r].Cells[0].Value as string;
                    if (i != null && i.Length > 0)
                    {
                        var m = metaData[int.Parse(i)];
                        Column c = (Column)colGrid.Rows[r].Tag;
                        if (c == null)
                        {
                            if (i != null && i.Length > 0)
                            {
                                c = new Column();
                                c.id = m.id;
                                c.name = m.name;
                                colGrid.Rows[r].Tag = c;
                                if (groupView.SelectedNode != null && groupView.SelectedNode.Tag != null && groupView.SelectedNode.Tag is Group)
                                {
                                    (groupView.SelectedNode.Tag as Group).columns.Add(c);
                                }
                            }
                            if (c != null)
                            {
                                c.id = m.id;
                                c.name = Conversions.ToString(colGrid.Rows[r].Cells[1].Value);
                                if (c.name == null || c.name.Length == 0)
                                {
                                    c.name = m.name;
                                    colGrid.Rows[r].Cells[1].Value = c.name;
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
        }
        private void groupView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Node != null && e.Node.Tag != null && e.Node.Tag is Group)
            {
                colGrid.Enabled = true;
                var g = e.Node.Tag as Group;
                if (g != null)
                {
                    GroupName.Text = e.Node.Parent.Text + " : " + g.name;
                    populateColumGrid(g);                                 
                }
            }
            else
            {
                GroupName.Text = "";
                colGrid.Enabled = false;
                colGrid.Rows.Clear();
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "truncate table TBL_ReportGroups;\n";
                var oConnection = new OdbcConnection(g_sConString);
                oConnection.Open();
                foreach (var c in categories)
                {
                    foreach(var g in c.groups)
                    {
                        foreach(var col in g.columns)
                        {
                            query += string.Format("Insert into TBL_ReportGroups(ExternalLogId,ColumnName,CategoryName,GroupName) Values ({0},'{1}','{2}','{3}');\n", col.id, col.name, c.name, g.name);
                        }
                    }
                }
                var oCmd = new OdbcCommand(query, oConnection);
                oCmd.ExecuteScalar();
                oConnection.Close();
            }
            catch(Exception ex) {
                Interaction.MsgBox(ex.Message);
            }
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void colGrid_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
        }

        private void colGrid_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (groupView.SelectedNode != null && groupView.SelectedNode.Tag != null && groupView.SelectedNode.Tag is Group)
            {
                var g = groupView.SelectedNode.Tag as Group;
                g.columns.Clear();
                for (int r = 0; r < colGrid.Rows.Count; r++)
                {
                    try
                    {
                        Column c = (Column)colGrid.Rows[r].Tag;
                        if (c != null)
                        {
                            g.columns.Add(c);
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        private void groupView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if(e.Node != null && e.Node.Tag != null)
            {
                if(e.Node.Tag is Category)
                {
                    (e.Node.Tag as Category).name = e.Label;
                }
                else if (e.Node.Tag is Group)
                {
                    (e.Node.Tag as Group).name = e.Label;
                }
            }
        }
    }
}