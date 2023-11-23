using System;
using System.ComponentModel;
using System.Diagnostics;

namespace EmsBMSReports.My
{
    internal static partial class MyProject
    {
        internal partial class MyForms
        {

            [EditorBrowsable(EditorBrowsableState.Never)]
            public DataTrendChart m_DataTrendChart;

            public DataTrendChart DataTrendChart
            {
                [DebuggerHidden]
                get
                {
                    m_DataTrendChart = Create__Instance__(m_DataTrendChart);
                    return m_DataTrendChart;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_DataTrendChart))
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_DataTrendChart);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public DlgAlarmReportConfiguration m_DlgAlarmReportConfiguration;

            public DlgAlarmReportConfiguration DlgAlarmReportConfiguration
            {
                [DebuggerHidden]
                get
                {
                    m_DlgAlarmReportConfiguration = Create__Instance__(m_DlgAlarmReportConfiguration);
                    return m_DlgAlarmReportConfiguration;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_DlgAlarmReportConfiguration))
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_DlgAlarmReportConfiguration);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public DlgAppConfiguration m_DlgAppConfiguration;

            public DlgAppConfiguration DlgAppConfiguration
            {
                [DebuggerHidden]
                get
                {
                    m_DlgAppConfiguration = Create__Instance__(m_DlgAppConfiguration);
                    return m_DlgAppConfiguration;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_DlgAppConfiguration))
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_DlgAppConfiguration);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public DlgBatteryReportConfiguration m_DlgBatteryReportConfiguration;

            public DlgBatteryReportConfiguration DlgBatteryReportConfiguration
            {
                [DebuggerHidden]
                get
                {
                    m_DlgBatteryReportConfiguration = Create__Instance__(m_DlgBatteryReportConfiguration);
                    return m_DlgBatteryReportConfiguration;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_DlgBatteryReportConfiguration))
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_DlgBatteryReportConfiguration);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public dlgColumInfo m_dlgColumInfo;

            public dlgColumInfo dlgColumInfo
            {
                [DebuggerHidden]
                get
                {
                    m_dlgColumInfo = Create__Instance__(m_dlgColumInfo);
                    return m_dlgColumInfo;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_dlgColumInfo))
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_dlgColumInfo);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public dlgColumnsConfiguration m_dlgColumnsConfiguration;

            public dlgColumnsConfiguration dlgColumnsConfiguration
            {
                [DebuggerHidden]
                get
                {
                    m_dlgColumnsConfiguration = Create__Instance__(m_dlgColumnsConfiguration);
                    return m_dlgColumnsConfiguration;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_dlgColumnsConfiguration))
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_dlgColumnsConfiguration);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public DlgConfigureAlarmReportColumns m_DlgConfigureAlarmReportColumns;

            public DlgConfigureAlarmReportColumns DlgConfigureAlarmReportColumns
            {
                [DebuggerHidden]
                get
                {
                    m_DlgConfigureAlarmReportColumns = Create__Instance__(m_DlgConfigureAlarmReportColumns);
                    return m_DlgConfigureAlarmReportColumns;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_DlgConfigureAlarmReportColumns))
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_DlgConfigureAlarmReportColumns);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public DlgConfigureViewGroup m_DlgConfigureViewGroup;

            public DlgConfigureViewGroup DlgConfigureViewGroup
            {
                [DebuggerHidden]
                get
                {
                    m_DlgConfigureViewGroup = Create__Instance__(m_DlgConfigureViewGroup);
                    return m_DlgConfigureViewGroup;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_DlgConfigureViewGroup))
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_DlgConfigureViewGroup);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public DlgExcursionConfiguration m_DlgExcursionConfiguration;

            public DlgExcursionConfiguration DlgExcursionConfiguration
            {
                [DebuggerHidden]
                get
                {
                    m_DlgExcursionConfiguration = Create__Instance__(m_DlgExcursionConfiguration);
                    return m_DlgExcursionConfiguration;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_DlgExcursionConfiguration))
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_DlgExcursionConfiguration);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public DlgNewGroup m_DlgNewGroup;

            public DlgNewGroup DlgNewGroup
            {
                [DebuggerHidden]
                get
                {
                    m_DlgNewGroup = Create__Instance__(m_DlgNewGroup);
                    return m_DlgNewGroup;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_DlgNewGroup))
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_DlgNewGroup);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public DlgReportsConfiguration m_DlgReportsConfiguration;

            public DlgReportsConfiguration DlgReportsConfiguration
            {
                [DebuggerHidden]
                get
                {
                    m_DlgReportsConfiguration = Create__Instance__(m_DlgReportsConfiguration);
                    return m_DlgReportsConfiguration;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_DlgReportsConfiguration))
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_DlgReportsConfiguration);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public DlgSelectBMSAlarmGroup m_DlgSelectBMSAlarmGroup;

            public DlgSelectBMSAlarmGroup DlgSelectBMSAlarmGroup
            {
                [DebuggerHidden]
                get
                {
                    m_DlgSelectBMSAlarmGroup = Create__Instance__(m_DlgSelectBMSAlarmGroup);
                    return m_DlgSelectBMSAlarmGroup;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_DlgSelectBMSAlarmGroup))
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_DlgSelectBMSAlarmGroup);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public dlgSelectColumns m_dlgSelectColumns;

            public dlgSelectColumns dlgSelectColumns
            {
                [DebuggerHidden]
                get
                {
                    m_dlgSelectColumns = Create__Instance__(m_dlgSelectColumns);
                    return m_dlgSelectColumns;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_dlgSelectColumns))
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_dlgSelectColumns);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public DlgSelectEnumID m_DlgSelectEnumID;

            public DlgSelectEnumID DlgSelectEnumID
            {
                [DebuggerHidden]
                get
                {
                    m_DlgSelectEnumID = Create__Instance__(m_DlgSelectEnumID);
                    return m_DlgSelectEnumID;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_DlgSelectEnumID))
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_DlgSelectEnumID);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public DlgSelectReportGroupTemplate m_DlgSelectReportGroupTemplate;

            public DlgSelectReportGroupTemplate DlgSelectReportGroupTemplate
            {
                [DebuggerHidden]
                get
                {
                    m_DlgSelectReportGroupTemplate = Create__Instance__(m_DlgSelectReportGroupTemplate);
                    return m_DlgSelectReportGroupTemplate;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_DlgSelectReportGroupTemplate))
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_DlgSelectReportGroupTemplate);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public DlgSelectTrentDataPoint m_DlgSelectTrentDataPoint;

            public DlgSelectTrentDataPoint DlgSelectTrentDataPoint
            {
                [DebuggerHidden]
                get
                {
                    m_DlgSelectTrentDataPoint = Create__Instance__(m_DlgSelectTrentDataPoint);
                    return m_DlgSelectTrentDataPoint;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_DlgSelectTrentDataPoint))
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_DlgSelectTrentDataPoint);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public dlgTableView m_dlgTableView;

            public dlgTableView dlgTableView
            {
                [DebuggerHidden]
                get
                {
                    m_dlgTableView = Create__Instance__(m_dlgTableView);
                    return m_dlgTableView;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_dlgTableView))
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_dlgTableView);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public Login m_Login;

            public Login Login
            {
                [DebuggerHidden]
                get
                {
                    m_Login = Create__Instance__(m_Login);
                    return m_Login;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_Login))
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_Login);
                }
            }


            [EditorBrowsable(EditorBrowsableState.Never)]
            public MainForm m_MainForm;

            public MainForm MainForm
            {
                [DebuggerHidden]
                get
                {
                    m_MainForm = Create__Instance__(m_MainForm);
                    return m_MainForm;
                }
                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_MainForm))
                        return;
                    if (value != null)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_MainForm);
                }
            }

        }


    }
}