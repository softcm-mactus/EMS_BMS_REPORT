PGDMP     2    6                y            mactus_emsreports_10    11.9    11.9      5           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                       false            6           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                       false            7           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                       false            8           1262    25656    mactus_emsreports_10    DATABASE     �   CREATE DATABASE mactus_emsreports_10 WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'English_India.1252' LC_CTYPE = 'English_India.1252';
 $   DROP DATABASE mactus_emsreports_10;
             postgres    false            �            1259    25657    tbl_datagroups    TABLE     �   CREATE TABLE public.tbl_datagroups (
    groupid integer NOT NULL,
    groupname character varying(100),
    grouptype integer
);
 "   DROP TABLE public.tbl_datagroups;
       public         postgres    false            �            1259    33855    tbl_enumvalue    TABLE     �   CREATE TABLE public.tbl_enumvalue (
    enumid integer NOT NULL,
    enumvalue integer NOT NULL,
    enumdesc character varying(50) NOT NULL
);
 !   DROP TABLE public.tbl_enumvalue;
       public         postgres    false            �            1259    25660    tbl_reportappconfig    TABLE     �   CREATE TABLE public.tbl_reportappconfig (
    id integer NOT NULL,
    code character varying(100) NOT NULL,
    description character varying(300),
    value character varying(200),
    type integer,
    used smallint
);
 '   DROP TABLE public.tbl_reportappconfig;
       public         postgres    false            �            1259    25666    tbl_reportcolumns    TABLE     �  CREATE TABLE public.tbl_reportcolumns (
    columnid integer NOT NULL,
    reportid integer,
    colnameindb character varying(100),
    colseq integer,
    coltype integer,
    colwidth real,
    colformat character varying(50),
    coljust integer,
    colheader character varying(100),
    lowcheck smallint,
    lowcheckvalue real,
    highcheck smallint,
    highcheckvalue real,
    coltitle character varying(50),
    enumid integer DEFAULT 0 NOT NULL,
    colmerge integer DEFAULT 0
);
 %   DROP TABLE public.tbl_reportcolumns;
       public         postgres    false            �            1259    34464    tbl_reportedevents    TABLE     p   CREATE TABLE public.tbl_reportedevents (
    eventid integer NOT NULL,
    description character varying(50)
);
 &   DROP TABLE public.tbl_reportedevents;
       public         postgres    false            �            1259    25669    tbl_reportsconfiguration    TABLE     p  CREATE TABLE public.tbl_reportsconfiguration (
    reportid integer NOT NULL,
    templateid integer,
    reporttype integer,
    almgroupid integer,
    reporttitle character varying(100),
    reportheader character varying(100),
    generatedtime smallint,
    generatedby smallint,
    fromtodatesprinted smallint,
    datatablename character varying(100),
    timeintervalinmin integer,
    dataaggregationtype integer,
    fromdate timestamp without time zone,
    todate timestamp(0) without time zone,
    username character varying(100),
    reporttobegenerated integer,
    outputfilename character varying(400)
);
 ,   DROP TABLE public.tbl_reportsconfiguration;
       public         postgres    false            �            1259    34098 %   tbl_reportsconfiguration_reportid_seq    SEQUENCE     �   ALTER TABLE public.tbl_reportsconfiguration ALTER COLUMN reportid ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.tbl_reportsconfiguration_reportid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public       postgres    false    199            �            1259    25675    tbl_reportstatus    TABLE     �  CREATE TABLE public.tbl_reportstatus (
    id bigint NOT NULL,
    reportid integer,
    fromdate timestamp without time zone,
    todate timestamp without time zone,
    intervalmin integer,
    username character varying(50),
    outputfilename character varying(300),
    status integer,
    progress integer,
    errormessage character varying(600),
    filename character varying(100),
    reporttitle character varying(100)
);
 $   DROP TABLE public.tbl_reportstatus;
       public         postgres    false            �            1259    25681    tbl_reportstatus_id_seq    SEQUENCE     �   ALTER TABLE public.tbl_reportstatus ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.tbl_reportstatus_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public       postgres    false    200            �            1259    25683    tbl_reporttemplates    TABLE       CREATE TABLE public.tbl_reporttemplates (
    templateid integer NOT NULL,
    templatename character varying(100),
    landscape smallint,
    isiconneeded smallint,
    footertablecol1 character varying(100),
    footertablecol2 character varying(100),
    footertablecol3 character varying(100),
    footer1 character varying(50),
    footer2 character varying(50),
    footer3 character varying(50),
    footer4 character varying(50),
    topbottommargin real,
    sidemargin real,
    sidefactor real,
    h1fontsize integer,
    h2fontsize integer,
    hfontsize integer,
    bodyfontsize integer,
    bodyheaderfontsize integer,
    footerfontsize integer,
    fontname integer,
    headerpadding integer,
    bodyheaderpadding integer,
    bodypadding integer,
    footerpadding integer
);
 '   DROP TABLE public.tbl_reporttemplates;
       public         postgres    false            )          0    25657    tbl_datagroups 
   TABLE DATA               G   COPY public.tbl_datagroups (groupid, groupname, grouptype) FROM stdin;
    public       postgres    false    196   �-       0          0    33855    tbl_enumvalue 
   TABLE DATA               D   COPY public.tbl_enumvalue (enumid, enumvalue, enumdesc) FROM stdin;
    public       postgres    false    203   .       *          0    25660    tbl_reportappconfig 
   TABLE DATA               W   COPY public.tbl_reportappconfig (id, code, description, value, type, used) FROM stdin;
    public       postgres    false    197   V.       +          0    25666    tbl_reportcolumns 
   TABLE DATA               �   COPY public.tbl_reportcolumns (columnid, reportid, colnameindb, colseq, coltype, colwidth, colformat, coljust, colheader, lowcheck, lowcheckvalue, highcheck, highcheckvalue, coltitle, enumid, colmerge) FROM stdin;
    public       postgres    false    198   L1       2          0    34464    tbl_reportedevents 
   TABLE DATA               B   COPY public.tbl_reportedevents (eventid, description) FROM stdin;
    public       postgres    false    205   D<       ,          0    25669    tbl_reportsconfiguration 
   TABLE DATA               #  COPY public.tbl_reportsconfiguration (reportid, templateid, reporttype, almgroupid, reporttitle, reportheader, generatedtime, generatedby, fromtodatesprinted, datatablename, timeintervalinmin, dataaggregationtype, fromdate, todate, username, reporttobegenerated, outputfilename) FROM stdin;
    public       postgres    false    199   �<       -          0    25675    tbl_reportstatus 
   TABLE DATA               �   COPY public.tbl_reportstatus (id, reportid, fromdate, todate, intervalmin, username, outputfilename, status, progress, errormessage, filename, reporttitle) FROM stdin;
    public       postgres    false    200   �>       /          0    25683    tbl_reporttemplates 
   TABLE DATA               }  COPY public.tbl_reporttemplates (templateid, templatename, landscape, isiconneeded, footertablecol1, footertablecol2, footertablecol3, footer1, footer2, footer3, footer4, topbottommargin, sidemargin, sidefactor, h1fontsize, h2fontsize, hfontsize, bodyfontsize, bodyheaderfontsize, footerfontsize, fontname, headerpadding, bodyheaderpadding, bodypadding, footerpadding) FROM stdin;
    public       postgres    false    202   ��       9           0    0 %   tbl_reportsconfiguration_reportid_seq    SEQUENCE SET     T   SELECT pg_catalog.setval('public.tbl_reportsconfiguration_reportid_seq', 42, true);
            public       postgres    false    204            :           0    0    tbl_reportstatus_id_seq    SEQUENCE SET     H   SELECT pg_catalog.setval('public.tbl_reportstatus_id_seq', 1577, true);
            public       postgres    false    201            �
           2606    25690    tbl_reporttemplates id 
   CONSTRAINT     \   ALTER TABLE ONLY public.tbl_reporttemplates
    ADD CONSTRAINT id PRIMARY KEY (templateid);
 @   ALTER TABLE ONLY public.tbl_reporttemplates DROP CONSTRAINT id;
       public         postgres    false    202            �
           2606    25692 "   tbl_datagroups tbl_datagroups_pkey 
   CONSTRAINT     e   ALTER TABLE ONLY public.tbl_datagroups
    ADD CONSTRAINT tbl_datagroups_pkey PRIMARY KEY (groupid);
 L   ALTER TABLE ONLY public.tbl_datagroups DROP CONSTRAINT tbl_datagroups_pkey;
       public         postgres    false    196            �
           2606    25694 ,   tbl_reportappconfig tbl_reportappconfig_pkey 
   CONSTRAINT     j   ALTER TABLE ONLY public.tbl_reportappconfig
    ADD CONSTRAINT tbl_reportappconfig_pkey PRIMARY KEY (id);
 V   ALTER TABLE ONLY public.tbl_reportappconfig DROP CONSTRAINT tbl_reportappconfig_pkey;
       public         postgres    false    197            �
           2606    25696 (   tbl_reportcolumns tbl_reportcolumns_pkey 
   CONSTRAINT     l   ALTER TABLE ONLY public.tbl_reportcolumns
    ADD CONSTRAINT tbl_reportcolumns_pkey PRIMARY KEY (columnid);
 R   ALTER TABLE ONLY public.tbl_reportcolumns DROP CONSTRAINT tbl_reportcolumns_pkey;
       public         postgres    false    198            �
           2606    34468 *   tbl_reportedevents tbl_reportedevents_pkey 
   CONSTRAINT     m   ALTER TABLE ONLY public.tbl_reportedevents
    ADD CONSTRAINT tbl_reportedevents_pkey PRIMARY KEY (eventid);
 T   ALTER TABLE ONLY public.tbl_reportedevents DROP CONSTRAINT tbl_reportedevents_pkey;
       public         postgres    false    205            �
           2606    25698 6   tbl_reportsconfiguration tbl_reportsconfiguration_pkey 
   CONSTRAINT     z   ALTER TABLE ONLY public.tbl_reportsconfiguration
    ADD CONSTRAINT tbl_reportsconfiguration_pkey PRIMARY KEY (reportid);
 `   ALTER TABLE ONLY public.tbl_reportsconfiguration DROP CONSTRAINT tbl_reportsconfiguration_pkey;
       public         postgres    false    199            �
           2606    25700 &   tbl_reportstatus tbl_reportstatus_pkey 
   CONSTRAINT     d   ALTER TABLE ONLY public.tbl_reportstatus
    ADD CONSTRAINT tbl_reportstatus_pkey PRIMARY KEY (id);
 P   ALTER TABLE ONLY public.tbl_reportstatus DROP CONSTRAINT tbl_reportstatus_pkey;
       public         postgres    false    200            �
           1259    25701    tbl_reportappconfig_id_idx    INDEX     X   CREATE INDEX tbl_reportappconfig_id_idx ON public.tbl_reportappconfig USING btree (id);
 .   DROP INDEX public.tbl_reportappconfig_id_idx;
       public         postgres    false    197            )   $   x�3�t��4�2�t�F`��!�1X Ȉ���� ���      0   @   x�3�4��ws�2�4����2R!A��.@������ew�28}�B}�b���� �)      *   �  x��T�o�0>�����QhW@H���H2�C\����vڢi����d�I�̇�����~�{��I��R/i����j^Ú��ԪM"�ו�I�EA5%�/:#��>	�f)/أ�T'Z��`10 Xj8�n�����aQ�B�����b����K�Y��p�-3X�������%�T깨$�,�r�+cP�K��`�&M��M���{S��R�w��41HmB9�3�m`�AX�D5���5f@b�Y_�̤ҡ�+
�3�"z]��Ʋ��E�6�Ɖ�u;ޏ��<��z�;h������'Ws�v�I���*b�0e���.�ؾ��!W�L�r�C쫂���ߗ�#����w��tzbR�N�����*%�u#��^��ys��DfQLW��a!�V���P��vT1H�|a�#�#��&�䈏�B�d��L�I�s��9:�G4�LQ��~�5��]���h��N�(����}������*y�.M�9�30�D�^y&_�ۭ��w���&%=Sf��*����T�aXm҆����ŰoE�N�ooLlB2��9_��T��	�_O�ь�I�I��_�����%l/P	� ,x���@��/Eg���������/���X��S�#v���(�BAI3�� |�h�(iy���>��]��A�)����(/]|[�#�Hm2i
��s�;���W��c���x9�BED�F¡�z�$�l>���'�h�:|��3X�Q���˶�j�~�&�8      +   �
  x��[�r�H=�_Q���P��ɒ�v�iid�;f���M
�jM�W�7̗��,�"�U)9�A��*חK�2��ҁ�t�� �0��o>��BU�V��<���_迁��$�2��D���z������Q|]������Į����yY����s>Y)�`(��E1����Q Ϣ ���Y̖bT,����Zj�J N�����iu��j�R	���,�����r��&�K1W7|����r<-�|�2��������|4:�?��ǟ�S��=�~��h���*_�;�}�Q�7�F0�>#�����8r��̹��/iݨ e�Y�p��R���X���Mߋ�hs�ć�d�j��x��,�Z��6R��ɰ{'a���`�����c2Ka�ì)#Ө��(������h���J|(�����?,!��	q�$g����k��qWL��9N�[�hI�^�)��J]�|���v�O�d��1	H8���9�rbN��A��z��������R�j *��� �%K5�$�Ie@��8�H��>?�7)�����rܢ|����������[TINg�b�w��B��	�74����2����!�h2���e9/g�30pO
qY���r�Ur I$���y�hFᦠ2
�*�/�S(#���H7�DU�S��&�$�|�ϧ��?K�� \\УmeL�z��>��Usy�P�5��L�	��c�v,�F� S/�5��3�je�Z�m�SLt���s!��%L�e@�V�Ú��t���r�����i}����!�	�X�|.�է(
�X�`�χbP�SpǴ�2�%D�=�:N��d^~�@֓��([��N<EGG2�^��9U����wJI�ժ�pk��:U6�ǯt��\èڜ9�RK|
#�b��W�(\��3��~#*��.Ѯ)P �m%�iݪwɏ���Ӭ7Ch�Q��0�T?�t�_yY �~��B7��j�7�;k�vV�N����k.O��Z
��*U4�+�B�p��M!�Ud�m�����B?(U l�⤩��Kձ]NFm����e�P�q�<r���-4����7��2Y��e~F�)�[HF�a�!)L���}��S	�U'�$���ԩ�Db��\;�K�*�A P�R�u�iF8|�!a� O��k�/y�]�O�T(SǛ�&!i��F~ИX��I@���ؘ�������zďU��1|�**�d�,��p�!R ��d3q�Oo��d����������U5�h��4#
m�`�4V�(>}�����t�E�^_��PT@�TLH�X5��0��ҡB�B(�Y���g� �3����9mNv*6;���2�ą��K����T*�y��P�:]b�ya�dJ��z�0U%�9�5��rp0��Z�nb��:a*�F�
��Q)Ky6JR��t�w�,a Ej���K�`�I�3��\��K����uMl�2�9I�nz�G�!�r�8��Q_s ih��5a��/OYb7:�9��%�ٍG�C���#���U��{W���F���v3/��6_�3�/~�"C�~ŧ���"�0���|���T&�c͉ ��O�ebK���M:�nfS�9A[��ީ���̉_T1T#:_[FQE"}DDb��_�1Iw��;_h�,�_h�,�r�LU	'<�e��J�B�$��[��"�n���(�p��wa�$�bm�%sd�H��f��b��Q�Lۏ�0*��u�]8�Jr����_��p�F3D:�n�2�cb>&μ�Ϣ�s�yW���p�{�\���Iv�8����";��0�Ҷ�Nz3��N�1FeZ۪�w�'��;��S ���7�+۫wuf .�o�	;��{�z�T�?-E�(���r�,gŃ��\.'Ţ
���:R�����L�i	D#2����BV`��:~�`V`fۂ���>=�X4�Ŭ����#.]���ܻ@�,'��У�y̮7J�؞���2��3�iët�W%�����������R5	��((���Pva���B�Z�"�>�D��y�S.*�{�b���je>D�5M�qN虫Re��!�t��9	WC���jJ�j{��ˊid�"?�Ic�vs� n��r�GE�Q�.��G�_a�ҽ Ӆ�n<�!�t�~��@V��ځB�Blz�xC��Cսf�ѥ�,P3��r��
��M�^g�Q�R����Q�m�Hz����1�t;����*���!O��O�l� fEl$@zu�N�D�W�V{��'���]�}W�e6�߹r�2��E�]tF�CƇ���!­ޯֽG�������2���eO}��j��kpڼ.�wu��i�}(��v�llrQ�'c�">d
���`�*p�.����Fȣ�ǌ֥ͷ�����*֔=�3�v���L�/����
�n�nu�P���O��T�������,�7�.�X���V|ܮ��hcuL����(sj稽�B[Y��]��*rwz�uu�6Z�ei��r�����*,j��n�P���/�l�X���+^Q�YeG7���j��{V1s_������I~=4�����ޮ��/�(��-R���U�Y������2��\V�l.+`W�Z�0̯SV��f�+S'[Z���cS��-�Gp�U�]�
�E�m������WH�잫��o��x�����$�v����I���-�7no;"���<�-ǳB�?���;$#��;���D�K�vq�Ǭ|���������Ƒ��_��4��)�oۗR	������ӗ_�/稨�r����g�����:Mm      2   3   x�3���2�`�L�r��)8�&���p�A�.�9� ~� ��      ,   B  x���Qo�0���_qOU'�d;	о���H$��6U�<0m$��	��_?;	��i�DAQp�����3ص\��X�� >��}ʟ`#�^g@���ݎI��8X��t6�F����A���K�B�W&�~�Ҍ�/�z�̏�=S8��dG&i&����/���+'l#d���w�e{v�F?0�#���#�'����=S�ĺ1M�$�p̧����㦰�.l#ÆQ��FB}�[[nL)?��&;�\�JFWL[	A��@�j�)���V��t\�׉ZMg2ݧ�ey�"�ڔ��������M��W���a�}���^,���5���P�TM�^��KY\�/i�
�'�ڍ-�k��8X��5�
Խ A�v�/��~0�5����*"Q����8���Ej@�t�C�4�A����H����h���Z�'2j�I�J��u�����N�x5��tP���@�5��ԩAq'��	���M7�j�������ꎀF��w�jc�+�V'&#z`���IA��V��,2�P�ߢ ������ib%��-�*�m� ��}��a��h��w�[��;��;�߫�ڥ;�� ۪?ڶ���p�      -      x��}]��8���ۿ�B �#&ξc�s����f����
(����U]h4�����Z˱W;�TB��I�۱��z��4NoҼ)���B}-��>��cR����?���������?���7���?~��O���������?����[�T���S���O+����?~-����������z��ӧ�?�ߧ�?>?|���������ͧO������7�&���߾u�g��������>���+'����_,�V�]����
������*(������a�fx������������~��M��<��/�}��3�5�����poJ�h��a�����\2�\�^�J
)`��k)ߥy��!-��-0�ٷo>����Y������O~�����?�|�m���L�����^&�Ö	;1Z��k*�V=��`i��ߜL����NaL��5Uc��	x��&�0{�ݯ��fԥk�?��[�����"ȫ/^2�����}��9H��."�'����O�G��3���3<�>��;<��<���w�\�?�E�7�!�x�ß-𘔯1�rXD����x������?�~��o����w�����}�����y��Y|���;k
]w.��yL�lS��6)�?Z�\�0�UF��咜���c�]����e�҂���!�+�\SRxQ ���S��,�5��J���b������>~�c8A#���>|�_A#(��c/�Q�ČZt	�)�U���v\�k����x�W�/�mz���?~�������ǿŕ��ҟ7?ա���������������n5�2Uy9GN�|�X����gh�����O�kYXR�����M���M6=�}5G-b`��a1��[��d��X��E.ư7T������v��Jo]Ɍ�,��X��a��Y2���/�N����N!��%������z���^�%�x:�I���_qq�6��>c��m8N��	�߫��ah�q��X�~C�3�
;<������q8,�Љ�=0�\	Q
l�+\[NJ�g:(��ʉ���׸t:�����{�b���|�\��.:bk�d�q��"�u�NY��ea�<��W��yA٤e9:U�1�	+J�H
�	OaL�OxBFL$�8T�饑x�A��Q�a]��0��Py�,j��8oR�kFy���eL6�CI�*4jk��æ�#\��@dIM}�KwO�q ��:�\�˵c����cg\;�Y#�|�~�Pi|��*��)C��5�	HY�$�M��x�\�� s򖃨��$[.f?c�i�;f�T�f�a�f��D�]�S�w�&]�V��7p��C,�=d^r&���`�f6#Q��!ɯ�X��| v�)#,,md�ark�)�39q���q���frV0��PI����W'��9�EOcM��SG�H]���Q7y5����UE7���BwhtLȯ��2���F��N�5�a�����q������S?����5<�8�r~
������/����9�w!߿|�?֫'��Y=���%W���N�$:B����/�%�ްM�On(����*_��8��/Ö���`�S��Sj�����`�q]���?����$d������s�AW��r���q7�bf���EwGk��%-Oψ�4oT�ިzz�1	c�ux�	�/�ަ�4��y��#�u�8"\��3�M/:`�ײ�&���n��%p�f͝[���X痓A6��/:����CA�2�uog=�y�vnx���z[m�0.�(q���y���<�R�]ЎW?�A���zP��9�c�����2vXK�(�X碘 xMk$m�,��v��K�d|�u��zZoX���~��{������hkc�5�9ǀո����� ���?~��;^2��@�����WN�'��������\|��(|T�Q�~����K;c{j��Z����W���~�ٕ
��v%�� Qɜ�w�KN_?_:c�M����X����ܽ}�
ۇFb�B�/�ͅBk�1�8�UUe>`��K?��^�R�.2)3B�������= � �(DJs�R���\��X���l�M��K���
�9�kbR�}wxfRdo�3�a�g �-4�٭f�Νq=��3�1��.����J�0�������a,��-������U�i	��T�L�
l-��ǥ��"i��s�c~�Ʊ~e!&2t��M/:�߫|Q\H���u>�u;�9��ozс��a�!��h��2�uo3� �<PH�q�\-5�eX�����c:e����R�"�� cM
0�Cɦ<_
Y`�*R�4��i+��p�X2��k�C�|�'��_>~����������|���;_;?���U�?�x�^Ͼ/���=޾Až*ja��=^�a�s$�u1�c�Ja�"x}Q��
a���u*�*(���G�<����F5ݨ�FU�nj�%��(�s��P���%�ek�V8�E��)��h������)�٩�G�����(+u$ʪ7!ݎ��GY�ZВS$0z���n�>/�)k	R:����|�
�<��� Ra�����`����/�>|���U҆}j����/�˿��H��w���1�%X�9U�Z�_V{�;�'SH�O����gk�/duY,[����9[t����w�?��	|��??����{����G��}���/�?}����,��v~���h�C���ף�}�hz��I (g;��Xd�8�'|��S�<�f�ȹ�~Ʋ~�xğ;M��;�leEa�q�s�a��j;d��X�����F�y��->���|্̖�SL[�4��	~�#���@��L�
�KFk�x��8v��ցMi��{_�_�W!4~̗��3&_�8v²�)F�X�����Q�u�ܡ|��"px\8
���4g[�R����H9���y!:eƦ�X�d����׼d����W�EK����C�G�x�E+�"PTL��M��f�+eXXT�i��(r$nm�9k�*.���i�{��p���L�,#v�z{t�����!~if������)�fy��(������g�������wxd��#����~D�ʏ���Z�8��A��k9�he��1�Ò.Ԙ�f���K �r���~�f%l^�К�����|m��kyB�������-�a@%���;�XLa>;
Y�p�R3�	���}f�J1<��Z(�zI��	^R�!�߰�2�D)���yj�cM���,��-2E����Hq�p[���'d�v��y,�8u<��gE�ƚ<;ˊ�Z������������ꤹM����R��OXѕhO5��0W8�$��`���}�}��dY�5���D�;>����֬&�ռ��[Y�cape*�tA��%;�9s��⏅��s���r3^�Ҍ�"��[6r5�����H�[<�m�1%\��JH\�9Q���Oԫj�-�I�W���*��o�QH@�u���3���0�u��1�z�����T������g�(��j��#]MOo�U��7��W�z�8�X�o����5�6���
_p����3�O<0�;�X�Tќ��*{
�u
�x��ou���������?�ޮ�:��ψ���?:$�;�}�T��<$��uɆ��;������ʡ�N+�]Ϲ��bȡ�Z�5dpƩ�l;��:�6Jc-�@/��uQ�r2Ӝw`ii@m,�J�m��MSr�(m^&��|K� ;GG�b�[zw��=�'�ɑ�;gD��-�5�,KXT�$zD����V�s�ҥI�Q�jU��1�+�u�ƺ0�po$��|�Tn �.�~ԍ!�<�����Q�mo;�暨��������R��$�]w�+M�x8��9�Hlڇ����t$VΕ�����*��y�$�z��9H�L��8�VM�x�ܒ��h}�J���͈I���qU����68l��h���;MO��ΤI���ᙴ���4t�8Ո��\9Y14���ᤛ'ko��<����R��ĶWZ��0O�L���cWU�<���Ic�FĜ6��r�B�X�y՟Z/`��Na�,~m���G    2T��4�s���_���qI?�4�V��4����V_GE�R햇��VѠ��}Df�V��aiw�T�O��叒���"5-�������@3��pn�)G$ϥ�P��erچ�̵eaqSמյ��Y�&�N��C�>�[Ŷ��$�ai�-U�wH+"����Ur�-���U�h���5:��Ҿ�Q9P&�}����LWk�$�G���B���+�eQi�v%��RJ����8ִ{����W][�,	�d�]�{-��sb9G���D/}�{z;힞�fV:��0�����sĤ"�
\�f��T*���C5]��A�� %0^�o�����q����{�c���V�[}�؋D���A-c�
���́�'^H��}n�S�
m��І#�k�M!y1�pq�7=���@z��@�P&fZ�:�x�0vʯ[J�*B��0_�R��-�]����y���7[T�f#pfϓ�f-c^Y�����᤯ڹ<N[H%>z�@,ӯ��АX��HhH��R��z�ߎe�E�x8��ܤ��A�*��8�3�\{�lAQ�3>XX�f�߈���5�L2{��5�E��e��1�K�xA/w'Z]��yز�݀"�e������X]��F\[�B3�<;��AT-ª����<�a�3�`
���':_�����H����W��|�$� �����ʇ��&���XSDpQ�Pⰸ�6pi�Y��;2�؏
� ǥOc�:���5N��׿�EL�[�7���Ϋ�a��?y�#���!N{ex�}��wx�C��=�����M7˘؉x��Y��;�|�"�2���JS[��oT}�<.�xȌ��"���T=�����4c7�~o3n;K0�����ch�����t�d���RM{�{�D��?���o���L(ޞ-���a7	Қ��~lBΧ�>a� �Q�U<nQ��4b=B��U�<���ƚxd����o�N&jD�|����X&S�S��W/H�������)0�M�c��W;a�=���_L;����g%�E%L7�6�p�M����SP4��k���Ԫ���k[Qmn�mGw���,,�W��X�%p��Ǧ0֚�5��*B���ah��DZ��$K4��G6E+��Y1�xl
%����W��;=�]P�o[����7.^�)϶�N���%F���f��}�Cc�籾�W�������a`�)"'6L�6e��rC]Y�qIY�tʗ�
��뒭�K3}/(w�B�
�a,�t�1n�J١,2�A}�"�/uY��aI�Ж0�W�W@�J���tuI�;���!T6_�N���?m{�kLY�G��ɗ؈0v�J�.޺8.��1)�_ ,��<l��R��Y�r({}�ԫ�E�6p0g��C?,궩`�-�@!����U%�`���Bk�t�*g�fu�+�׎i��˵c��T�'�`�/Fy�.djU�X��T�n�״���N�����.�J��!��EH���Z�����<������lK\��)ku�y��C��"bs?��Q��93��lۇ���C�����ґ��#�5�GAj��pw�耛x"����8���:��@���gR����Lٚ�z������~��`G�Og59x��Y��ga���,�re7�
�ǔM��4;}�*��v�wZ��W�b6�ᾌuR���'8�O{e�S_���Ø��,?�X��=�U���������JK\	��9����a�/��Q�xn�+8-%QW���=�㒺:�/b���E�¥�x4k��kظ��c�
�7���FBe���E�����/W����媵����p��-J�h���2o V��y+�����;Z�񓾣m��C�߆���.G��$��W�uN��s_��5܍㡈�����5�;K���ޒvUKƳa����(�`xV*[�����U��s�εܜ��k_�-k?	RV����$s��[8��Za����6��5mPr�/?��\�4�*�TĜ$��ZWA2��lњyM�Q¥`��^��;h���{��aE~wı��C�.͋�8���0c����Ai�X�i�������4����R�,*ɐi��||9�r
���Úƚ��\�g*ZO��M����M��X�y�ɚX��'^��S֦���nqGvq��Rώ�a0��Щk�gMfRK�a�'F�����6����,l��'�2m�j�����
�^������-1�^���f�J��.mbi�M,d��)`��lTt��4�\�P0�1�?/�����B�p9�aؗN7�)�[*�7�X(L-/X0���pY��g�*��t�b��g��@�D)K���`�}�*�G�d���p�,#���P%Im�{Xi���7è���a����
��#e���˨�����ä�3H]iN"u��� I�	w�l���<.��iz�)Z!�+8��)*���0&�lf����v��Zd�v�嚒R*Z��"���Ζk���O`��df�AP�%���ڨwӃ~���F��+�9k
�����<�Ezne��W6Uƛ��_XA��אp��)�}g2�145�bOH�(0A}�2Ui����-��@;z�Z����ֵb�<�!mAϓٚ��ޓbY0���~�~5�ir/�e ���Il}î�H<E�+�R���Vֆ�^I�m,9��G
�tO?���9��E4�+�~�i!����rXb���9�+����x�%�T����0��`�Ӎj�ÙT;��pL4�c
�/-����M[yB�C厐�8C��Ÿ���QcKN�����ޓ(bh�h&�#�B��d�ٰO7������vr|Ceh_yk���
ƚ~�G���n5�)n]�l��9��8G�� �h���$Lβ\Z�*c�*�0�� )])�e𤸊��<^B՚��8��N��#��V�c�֜`&s�\?A��V(*5l�WN��'��;�P醠��np+�M�]	����4W�ׂ��-���U����Mn	�5Y�K�ųV��C-�wR������f
�0p��n`�#��G2.�Z���0�yk�k�9��V3�E��Z0a��o�9]�&��j�$�&l�7:u7�y�rá,�W�\��4�g�>Ɔ����c�Ҋ����|�{y����ԶC������/�?�Bǐ�|yX��&	�a)i�E��;:�tI�m8rܚ���d+�yX����6P�oY��T�Fg��OײH�9Su��0�/�|�W�U%�Xl���� �K��
נdW����t�iM�B%�b0w���A�,*�-�#�3s]H[+#â��Ѳ^7�j)�Ĳ�ZKJ�@���7���,*�V/�A|-�׫��b:����������
9��B�zm {w�""/����މ_g���^mb����(8�t�o�=�X(��VR��������
d����Р�0��
����޺��1fqW����:h�7�P�q<6�}U�el�êl}�&�@:� s���{e��jV�۔}�Ml�"+���1I@_7�|���,�u�d�鎄6<�GN��X��ߧݱAV^>wXK+P?�N-NClF�[����:qyF�@Y���+�?�B�(��Sn�^�)]U�Q�L��{��'\4�-e,�5,�w��<_ :߼�X��QrKKމ_k�67VyN����u}�a��e~��<��U�9�"Z.���k�iY��2�(��4������O� #�l-y����1�RHw$���$��/�sC�z���$�a��C���;�c}�`S�X��.
��z��Bd[#�{��,���*�ķ�v��"{��I)p��B�d���[�f)%��>F�L=4����]ǚv�C�����ga�� Eh�W(����� �n�y�U,5���m�;X U���ߡ4�j3��͈�j8���߯`��Jo0���m���W��8�_g-v����
��.˶��C�򏰮!#p�,?�姝�Rv�qʮj��Ȳ�����J+[�D�O����@��_aa�5y^DiԂ$V��YN:�/>��I����@�]1�4��+�I��U��T,�c��7�����&����-J����bp�2u�%�� "    �o,�n,T�y!���L�n:�Y�e8�j1��
���R?B/I~�2ֹ)\0��:��5=���I7b%l�>bi�NcM?ڠi+��'��6pISAOqdʫ}�{U����9�r�Kj��J�T������ӴB�W�4f_/����~��ts�B�J-�?,�����cз��D�l6[��PbW���>�c���<�6��K��įJ�N������T��$4��!�������{4��2Qr�=���6��6K��&�}��[w�ԙ�VE\��F5c���Kˬa�
v��a�¿"��,�n�"�;�n~�a3XL�T%(I�D���d6B�����V��J)I<��{�da��-����)��-�j�
�۴��J��IV*ɕ91���+�w��2�Zr���a����{�	�ҋjM�萝����&������ŷÚr��5�Bq��r��;��(����������9����$)�z������6�ˏ�@��k�Ϡd�u���u)��+V��!�6�������=�g#�:��|���OE��/?}�{��eK��p� �W�d_���T�X8 ��Ž@Y��H�#��p�H�����? U)�� Y�v�Tr����N�YYὼ��\�E-ӆ<�u岺�P?W��X#kJ�\��6��a�k���ݛܑ0��1cUo�Ppۺ)Sd��
B3���[�ĤW�+g�����ڴ�{�wf�Zz��F�*�G�zP��SG�u�۪��:�����t����j#�K4�t���������O���ϙǥ9+��{�����{Տ��W_���3S���2���������hW
v��6!u^��Z�'
�e}�+\RU�jÝڋy��&����aFr]?c�����ǁ�8���!d$Q�Gk,t�<�+ٖ�����
�zopYϊ�΁������)�0"��g(���Nn�1*5텳���W6E�j�|�w��rcƚ�1q�9hG�i_<,EwO8�UĞ����
���HB���-����y �h�V!LҮ~I;��v����p�*��b��0]����z���/��ԗ���R����s�8.��������B�ME�h�����y��L�&�v�g��J����*�c?=$��ű�_ q3�z�a��8�u���/�B���Z�R�����K��R���jo"�Yjyz+f)$^���Ā�0v�1&��+�W��o�Q�^JAX�;[	�n��as�@@fΨ�8`�mNzǜ�v�C	�"<��9w����T�:3AB#Q"�C�ء��ǚ2h�ـ��C�Xp+)�l��}Խ�$Z/��٘���+��W�z�M���	�0X�A�!Ȝ�y_�W��#�D��[y`����rHI�������9���
r�;��P����&�'��.F���.���Tv�J},a�z%}���[��
�|�����XۖgO���N�Pz��D�HIn�S�r^Y��!f�ΌɄ֌��Ooi��eIN�sѺ����Ԍ�u+v�8�0�����,�ϵ�����!l>�8�=��o�q�U�:@���(�[�J�m���*\�-�I?d|��i̘��]'v��i���숳�tM�Ѣ�������ٙ~��c�-�=�Bȭ�͝���E�>���K�c���	�/c]5C����G6�T���1�]��۽,f�����:�flzgl���5�������<��u+i����e�s��S����6��谮�a}�"�j��,,1;VOx�(����=�Jy�jр,�_�~�N9Hޯ�"�����%��aD��l�}8��	�����\��j9������v~�{��j!+��f��<p����Nw��TW|�%�%�/$�hRL.���_8�w�,m6;�$
.�N��f��>���w�gW����n.q�D�n�1�,
�t��;ϼF�q'c�K�:I:r�J:�VQ9�`���mu��E�ӛN}���b0�R؏2G��c�^}���e��"A�7���.G���:������u��ky���c����{,��?������f���Z�j��<R�&R��K2 �?95�4��	���ʌY�1)*uÌm����8�C��Tŷ1���X�bk+��}�^�Ka��t�'�����kE#���)�,�JqOhu�r$>x��7̨w@E}	���M�*�ɇ\%9ısV`N`��w�?�\B�>���������������?��x�/�?}����ܳ,]��}/<}=�D�H��|�KWx$��=������ɓ��A�������o˟���Y^iS�7�������s��� |��%�3�$��Zf�Cb���K_�ph�I���C�R��[��$�����4vJ��Q���%�\�!���%�r����p�͠�n<����Dj,_��U�p���F%1���ҥ7$�^�c��kD�����\y^p�Z�}��Q�n�`Q�3�M���o/��D!�V�<N)�/y�
�����6����_�K������l�.������1��<���`�����Y�؆�#&r.op�W>�<,�L��4mJ�]`�Z�K+��=�������r�K��I�@kS��%/��,�P��!���U�U�6�I֦
�����O����4Wx��o�����ױ�w>��� �g�{D[��qI�Of9����UMy1��Td_� (w ix*R-v��=]�:�S����������
p�d���8v�!d��jxx�v��6}���U�Է��,9Ն7�:q�S�Ő���Ŗ�|Ǔ�fe2^��q*2����	��B|,�¥;I�ZI!�@BͣYW_��T��w�,~�LJ�œ�Y~�b�Sr��N�m���l�{(�A�n�Y�Z��K{Ij��/��;h���d,f,�{Ò������y5�n�ֻ����Z�"�7Āؚ������Ӛ9�8p�����iL�;�3GuxA�hZ<���כ%oK�d�*�wӹ�!n�$��q�]p���#om.7#FY���VM���E}��ŉ�(H�I�}5W��c�oHcݕ�T���Sp���-������zv&�:$�u,3����^�۾�H�dk��d�W���� [�aaI��R��D`��� ����샯7�	9��ƥG�Ara�43����T��V�8G)Φ���t'�6��N�q��ʢ -h��������Tcq0��
�J|c(d�M�T󙆇��Icg�8mz��>P�r���ޑ�k�XX:�7�c�$\�D�.#k�/��e�zk�dF�]qˌeM��q�hG\�RS������t�6��ӫ��e���3�YI�+�pu|! ݚ����Yct�C�+[�\�����GjW/�5<Wv�7/x�EY�n��8C�v1���SU�N�!�G�.���.'R�|6�I�ym�}��6��h�r���#U�%�w�����Nc�8]�p��w��*�.��<.�4,B�Q�ś�e.c���VgQ��N㭡�:���
B/C�h������Gf�*Ʊn��J��3�;߳?qZҶ�.����!P��cM7� M�j�>x)m��T���W!�X�RM:�7/��`�e���=;Ch��+��፸=�\w�H�� c-�@13:VKs�(������pӦ��7-��x��o��{
�j7��@2�^�>!�v _mv�X8���]��8DM��q�5�b��(�"�����Ȅ�m=5��{����#a�/w�O��<em0E�A�66Z�ɶ����>|��W��s�'E���0��Lj?�AB��mW�>|a�5Y��y~�3����0c��!���Y��7����_J��/C�&T���r�զ�,
yƬ(�x�SJ\ƺd`���{(IK~�FI�n?�߷G��Ux�����/���W��k<.�96��h�o�V�zf7�{�-��%��"Ϫ�k\S�2����VAĝ�B������C���~}+�3�[^H�:���:�F��?M�;�U���b5�p����'���ūr��ɏ�*�c����|�_����t��l    ���E����~�sX82=7����r�oy]S(FcN*F3�;e?�$�(;���90;<~+$o�mg
ɛfչ:����i�h�p�;�Z<(���C�.n�5�Xg��X�V�_[��*U2�U*R�CG,cgA����T�p���
�M;_��d����A[_w�*-%$
��^�>�y�J4���&�##vz�U�_���io2�i�Q���jr�A��^Q[��P�tv�0�����`"�B��{C�F�WgC�V8 $6����&����v�
߇/�["yޗ�nԢ,���P���wz!D ,x!��RU��x!�>�c5��E�W4[��h��ZZ�E!�~Ȃo.���JA+�{0���¡I��m����M���	��ױ6�悝rOpx�S��%�U�`ag`����e�$X���k �'Ǣ �gt4�f���I���})�9ٝI�>PȤ�$K������
�蹫u,�b��n��/��&��I��i�;���r{�S�@��5�
����O�"���{�T3�_��Aw0��x�U�+�Y	�!�����3��с��Aa�JFVJ>��A�X?SY�#LU��B��i n��A�ݞ ����6�|��I0��+[�[d�SA�V"�7p�s�������oMc���Tm��� ��IR�q���Ri�����;�<�Q�Q�cޑ�3���NcM?� Ϛ�Tm-u��A@�q$���3�l�D C�C^��+Oc^�q�vz���m)�����!���f.�+�$:��j��Kf��7�����͹����]��;�<��_U/�������^�|�����V�M������:-�ع`;�{���t�~��o��8�O��'���������� �V�}�Rm���ZP�̶������α2�,-�t�	��>�0�}TjU<P��kP.~����v����w:�B�Z�a�|y�x�dF���c���'嫴[y�<M��/�TJI�<��s�l�t+7�M��^�8fNp��.��H��p0eK.!��G�Gc�4j(ð�!s�%�vDm�o�䕑{����~�$�.Po~�h��&�s���!�l��{(�Ǝ��.W�Qo�ܭ����iͭʼ���ba!4��(z�7���:��Ym_K/�e��bE�����Y��P9�A!~����A��h�c��[��D>��E��,2�XӱN�T���^�}����ĭ1��L���<����1�0�������G��,�<���T5X�i./_�zX��|;��`OJs9��i.�P�y$�[F;�2����έ�;\�YQ�����ް��i���MgH	�.?�2� �Bދc�w+zE�W��//،ŚV<$M(^ƚn�1-j���f��}�R�4�^2K2��IF:��hŞ@ k0�w��������@��1S�y�3�VJ'�0��Pʁ������R0ִ���Ah�j���X�t C3���޾��S��T��%7�
wǭ��ZW���BI�ӗ�@C{��;�c���]X�>P��W*Ϥ�<��ڹ�ǡx���x~�]zb��}��&Jg��pa�����s�<
��&\��)r����rt�b�y�������E�>ȓ%.�+�
�T�[@�Cx4tv��5�H����>P�}�T�k���j��EA��w{�X:�V���@HW��X��* ���R�Re�*C�$VB|�w�4�ʯ>��N�Dz���Bw�w)�����z+[��N|�!3
Z<�UU��n��Sӛf�>|�uM��� !Ca]��\���X7�*7��X��ԝ���~'̥�B�t'�����T�,�*��e���4�Z��wwA9��3�*�'��;J4Z(~ǅa!�&7Y؉Q)��˦O�;U�v��0dX���Z�t���Tp����ǷR�����
��@�F�Π�M���,G3�&[��>P Bq�U΁{и�4��@�M�sv>��s�'�iЏg���,
�$���z|HA��k�ˠ�! !��,
�n���ׄz]�2R�A����~��ފ�	|�6��he6�;B�؛;�XM�=�����*�^:N8�c���ǺY�t !���w��&*O�OU�k�q`��7^�C�(�P��>h̚ĸ��1d�e��-2��:m�Lym�VsGԹ��`C2P�2p,���,��<��!�k:KS�(���tl&��|� S�\'��B�q}N���?��R���2�q��T�̸�����,�}kp��@�F��w���X�C�ľ"���9|��S;
x���o�$'��̎�ǝ��e8�]?%�j'Љ.��;@'��++d.�:Hym��~]��:H0�uw$����ㇿ�������1���ɿ��_����j��$2�g*��֗/*ʹv<�ܗY�-�篾�����D ��s���̨w@E��@�C^�^=���t� c��]�
����J� ����S��r��X燴O���_���:Zd 
� c���<P_�×��P��`�7������eŞ��!���BZXK@jz��O�H�is�{M�|�t-���m0�LǗy��<v�b�HwN�_�`[��:Gg �L��ݚ2M�D�~�(�/(Ŋ$x]O�X�b�8�G�q�1қ~�y<lm��0$E�?v�Q�����*4�gVg��M�aC�Z$��m\�4ɢ����&L��D����L��51�$U#P��;Z:AV�B��SVb�ƽ3v4���(��C�]�BOxŮ@�����Q��C�Y�K�ٹ�(�M8JeC�
�QJe�y�п;P*��)��f'���x�����iO��@�Ҟ��T�{�4g5���421G�vE��l�D�|x�mGS�����i��%��ٮ`�_�� 5ٯ��F0s���]�v��^���),.�\E/����ᄜsq�)hV������W��O�ؘǺy�����J�2v�w��&�]Ck��_�V���:��:S)�g+��7�͑��/ʁ��d�fҺ����6�Bq�m+)G�tG�e�\�� �7Ww�B�%r���J�mXM�f��R�,
$K��o0Bk7C7M�e<��\�4���ƤP���a�%F��ް�kf>�Jʇ�d���v�zIzeH����I�0���=$��W� z�7�v�K�5�o��tms�0d���
s���u"�#�bC�?���nY�4�0��5		V�l��΋�.q�'�s@�`0cK.�;$��γ0��$�^~�� �$��XXR��q���;��n��`ahW(��xî��֓�z������fY��́x�֟ i�b*���J���?EJ��y�Ɍ��P4R��i6;��V�yЪ%��P�5��^�����O�������`&l�f���4�蝷��q3l�<�P��F��c�,g��9�`Y�ێ�*��iQ�Ȣ�l���l��݉/t��o٤�v��t���k������C��Sxt��[�B���������MDN*Mm�@6��.8�;1� �MŔ�a`�K
]���J�&���4����4�X?�m�Ð�>PPP&�Ӑl^��B����00�yۯ�66�"][ރ���`�ۆ���S�t�՘76��J�"+o��t%��E!#cȪ�xV�d�`d,c}FFP�C,��@B_�'��}��da�Ӟїۤ�Yi/΢���Ou�A�!��@��7����G{�0`��1����j} [S����_�|4�6���w�F��5S����l���
"�ղY�i������g��O06�X�E��r�E�����C�u��k�Ԇ���g�$��@m�dZ-����{N��b,ه�X7i�2lj�;(��irz��Qe�ơ@�	��6��R}��kP��a5���w���IGRP'�k,+�hxXR3�H)��ÜT��aQi�i�3�.]a=UK��0ď�5?���U�_��G��.�G���X�л�O��f�<�^V٥DZ�sIK����5���v*�ܲꡨ}���q:^����0�w>P�����|Ǹg%��E!ۖ=b��$���^ �  ��ǡ�2g%c�S�;��E���"�^'��!�0�������l�����I"VW6���dCM��kb�L᠝fC����eH��-��ﮛ���l�_"-�uu�M1+����@a4��r���\_�P�.�m�޳�-I�+�+D��uƪF�Ò�2�:"n0I��C��7|�#�1��YX�δsꈖ���#��dsB�Z\����{�N�xL�V'�a��Q��K�Z���c7�J�ّ��`����8P��y���[ܫ(���� }F�M24�%&�~{�����l���d�VMg�t|R7���k+�&�>����V�f=t$�2�X疱�M΁-�>P`{NغE�3��v��]��޷.#������ɛ!��_p��q-`'���%`���y�������C�9�B�4g�N�����{(	XJ�\]UK��%�HWPᆇ@��ƺU�aWm��J���w��b��0���|�����o�&P�מ�#PZ�v�;�&l��5y�~}-���l	�nk-��*�n<�X�t�}9=+5�X2��>c�T�h���֚��k�O�c��<�a����"�@��"�����H��t��i2���eGojr;(i?ꍨm�"�$�j�Cs�]����W�x��%�|����zD��#\=d����'D����xBa��������%{�e���-���3�{෰~��-%b1��ԟ^E':��N5)��!���]����y!�4Dp/n����z��Z���r����kpG��U|a#Q�v��Yx]Lg�J��ԅ�^6[I����e�,�9�f��l{O`�9(���y�`K��0���?7q7�v>P�1�e�F�����=��x_`�,-�p��'�����vaĘ��)�9�k��LN�k�=�+b���~s�{�Ĳ�K_�/�Y+JJ/�ujJHY�Ϩ��V.8|��3�,�k
��P���Ҧ
%��嫵��t�f(���1��>�?F5�>���4�#���_���Z�jȵ�8֯u����
����,>q��2�ls^0�p��
�_�br���΋n�љo��Z�;(y��M}p<S��y�P��wU�&�f��7�Lѹ>5E�k��24c>b����!ls{���\<,��$��x�{BSA�x��Yز�������������      /   �   x����J�@��'O�'���,�d��6h2m(�� m����8T�0��ws�n��s�0׏]��a��k�CUZ�6v�Z-5ZsW+�jt��*���h���NW��&]��9z<) ,�q%3�OGa dbP``	;��.���&�lI�Y�?�ֽ���������A����Ic��<Vp-�BNW�9<Ń�m���ǘ9TP.tyz��D�����1�[�sL��$I� �x�     