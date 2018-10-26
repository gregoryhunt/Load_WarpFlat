using MongoDB.Bson;
using System.Linq;

namespace Load_WarpFlat.Model
{

    public class CellInfo
    {

        public BsonObjectId _id { get; set; }

        /*0-0*/     public string delflag { get; set; }
        /*1-1*/     public string languagecode { get; set; } /* LIKE SCREEn DRIVER FORCE VISITATIONS */
        /*2-6*/     public string menu { get; set; }
        /*7-7*/     public string seqlevel { get; set; } /* LIKE SCREEn DRIVER FORCE VISITATIONS */
        /*8-9*/     public int rw { get; set; } /* display row for data */
        /*10-11*/   public int cl { get; set; } /* display columns for the data */
        /*12-62*/   public string lit { get; set; } /* Literals displayed on the screen */
        /*63-63*/   public string clr { get; set; } /* clear fields after writing record y/n */
        /*64-64*/   public string shw { get; set; } /* Show this field on the screen  Y or N */
        /*65-65*/   public string fil0 { get; set; } /* SPACE FOR RENT */
        /*66-67*/   public string[] reqk { get; set; } /* required key sequence [0]=EDIT&OTHERS [1]=ADD */
        /*68-68*/   public string packind { get; set; }    /* pack the number */
        /*69-73*/   public string rmenu { get; set; }    /* relationship to menu element */
        /*74-74*/   public string reqfld { get; set; }     /* required key
                                            (Y)es,
							                (N)o,
							                (S)election
							                (E)ntry
							                (X)entry
							                (F)ill
							                (A)lways and Match a Table if one exists
						                    */
        /*75-90*/   public string typ1 { get; set; }   /* type of data */
        /*91-91*/   public string totals { get; set; }
        /*92-92*/   public string hmenucode { get; set; } /* Hire menu codes */
        /*93-93*/   public string stored { get; set; }    /* stored in record  only 'N' for not stored */
        /*94-115*/  public string reqkstr { get; set; }   /* key sequence [0]=EDIT&OTHERS [1]=ADD */
        /*116-121*/ public string editc { get; set; }  
        /*122-122*/ public string dups { get; set; } /*  allow dups to key fields  Y/N  */
        /*123-123*/ public string nocalc { get; set; } /* if 'Y' then turn calcs off for this field */
        /*124-125*/ public string[] vst { get; set; } /* Visitation for [0]=EDIT&OTHERS [1]=ADD  */
        /*126-150*/ public string selcalcstr { get; set; }
        /*151-151*/ public string updateassoc { get; set; } /* update the rel to menu file if in memory */
        /*152-152*/ public string special { get; set; } /* Special exception rules */
        /*153-153*/ public string form { get; set; } /* FORM TO DISPLAY ON */
        /*154-154*/ public string popup { get; set; } /* allow a popup window (N)o, (Y)es, (A)utolookup (E)scape or Cancel on Add*/
        /*155-155*/ public string justification { get; set; } /* right of left entry Fixed or Zero*/
        /*156-156*/ public string fieldstamp { get; set; }
        /*157-160*/ public string[] xxxx { get; set; }   /* SPECIAL HANDELING EX INV NO UPDATES */
                                    /* SPEC[0] = UPDATE THE INVOICE NUMBER THIS FIELD */
                                    /* spec[0] = (L)ookup   */
                                    /* spec[0] = (Z)ero out output record */
                                    /* spec[1] = CHECK FOR UNIQUE KEY EX VENDOR ID */
        /*161-161*/ public string bkupdt { get; set; } /* update in bkrgound or (S)weep */
        /*162-162*/ public string showonlog { get; set; } /* show on log file */
        /*163-164*/ public string[] att { get; set; } /* [0]=inactive, [1]=active attribute */
        /*165-165*/ public string inputdevice { get; set; }   /* (B)lank=keyboard
                                        (S)canner
									    (K)eyboard
									    (X) Allows Both without C/R on scanner
									    (B)oth is scanner or keyboard */

        /*166-167*/ public int reclink { get; set; }
        /*168-168*/ public string linkonchange { get; set; }
        /*169-171*/ public string filler { get; set; }
        /*172-175*/ public int fldid { get; set; } /* security Id */
        /*176-179*/ public int secfldid { get; set; } /* security Id */
        /*180-181*/ public int associdx { get; set; } /* associated index */
        /*182-183*/ public int typ { get; set; } /* typ of data */
        /*184-185*/ public int page { get; set; }
        /*186-187*/ public int stcol { get; set; }
        /*188-189*/ public int dcps { get; set; } /* decimal places */
        /*190-191*/ public int st { get; set; } /* starting positions of the data */
        /*192-193*/ public int ln { get; set; } /* length of the data items */
        /*194-197*/ public int[] rfile { get; set; } /* relationship to key file */
        /*198-201*/ public int[] rindex { get; set; } /* relationship to index */
        /*202-205*/ public int[] rfld { get; set; } /* return field */
        /*206-221*/ public int[,] rdisp { get; set; } /* display fields in windows */
        /*222-237*/ public int[,] rdisplen { get; set; } /* display fields in windows */
        /*238-245*/ public int[] drfld { get; set; } /* extra return fields  */
        /*246-253*/ public int[] drfldto { get; set; } /* extra return to fields  */
        /*254-255*/ public int times { get; set; } /* integers input */
        /*256-257*/ public int literaltop { get; set; }
        /*258-259*/ public int fieldtop { get; set; }
        /*260-261*/ public int literalleft { get; set; }
        /*262-263*/ public int fieldleft { get; set; }
        /*264-265*/ public int fieldheight { get; set; }
        /*266-267*/ public int fieldwidth { get; set; }
        /*268-269*/ public int w7tabindex { get; set; }
        /*270-271*/ public int literalwidth { get; set; }
        /*272-273*/ public int literalheight { get; set; }
        /*274-275*/ public int shortenkey { get; set; }
        /*276-277*/ public int startlen { get; set; }
        /*278-279*/ public int oldfldno { get; set; }
        /*280-281*/ public int currfldno { get; set; }
        /*282-283*/ public string temp { get; set; }
        /*284-284*/ public string hidden { get; set; }
        /*285-285*/ public string joininrptandtrn { get; set; }
        /*286-289*/ public string parentscreen { get; set; }
        /*290-417*/ public string longliteral { get; set; }  /* Long Literal */
        /*418-418*/ public string w7fieldtype { get; set; }  /* (C)har  (N)umeric  (D)ate   */
        /*419-422*/ public string fieldidkey { get; set; }
        /*423-424*/ public string fieldmask { get; set; }
        /*425-426*/ public string fieldfontsize { get; set; }
        /*427-427*/ public string fieldbold { get; set; }
        /*428-428*/ public string literalbold { get; set; }
        /*429-430*/ public string literalfontsize { get; set; }
        /*431-462*/ public string literalfont { get; set; }
        /*463-493*/ public string fieldfont { get; set; }
        /*496-511*/ public string wintypestr { get; set; }

        public CellInfo(byte[] row)
        {
            delflag = row.Slice(0, 1).BytesToString();
            languagecode = row.Slice(1, 1).BytesToString();
            menu = row.Slice(2, 5).BytesToString();
            seqlevel = row.Slice(7, 1).BytesToString();
            rw = row.Slice(8, 2).BytesToShort();
            cl = row.Slice(10, 2).BytesToShort();
            lit = row.Slice(12, 51).BytesToString();
            clr = row.Slice(63, 1).BytesToString();
            shw = row.Slice(64, 1).BytesToString();
            fil0 = row.Slice(65, 1).BytesToString();
            reqk = row.Slice(66, 2).Select(b => ((char)b).ToString()).ToArray();
            packind = row.Slice(68, 1).BytesToString();
            rmenu = row.Slice(69, 5).BytesToString();
            reqfld = row.Slice(74, 1).BytesToString();
            typ1 = row.Slice(75, 16).BytesToString();
            totals = row.Slice(91, 1).BytesToString();
            hmenucode = row.Slice(92, 1).BytesToString();
            stored = row.Slice(93, 1).BytesToString();
            reqkstr = row.Slice(94, 22).BytesToString();
            editc = row.Slice(116, 6).BytesToString();
            dups = row.Slice(122, 1).BytesToString();
            nocalc = row.Slice(123, 1).BytesToString();
            vst = row.Slice(124, 2).Select(b => ((char)b).ToString()).ToArray();
            selcalcstr = row.Slice(126, 25).BytesToString();
            updateassoc = row.Slice(151, 1).BytesToString();
            special = row.Slice(152, 1).BytesToString();
            form = row.Slice(153, 1).BytesToString();
            popup = row.Slice(154, 1).BytesToString();
            justification = row.Slice(155, 1).BytesToString();
            fieldstamp = row.Slice(156, 1).BytesToString();
            xxxx = row.Slice(157, 4).Select(b => ((char)b).ToString()).ToArray();
            bkupdt = row.Slice(161, 1).BytesToString();
            showonlog = row.Slice(162, 1).BytesToString();
            att = row.Slice(163, 2).Select(b => ((char)b).ToString()).ToArray();
            inputdevice = row.Slice(165, 1).BytesToString();
            reclink = row.Slice(166, 2).BytesToShort();
            linkonchange = row.Slice(168, 1).BytesToString();
            filler = row.Slice(169, 3).BytesToString();
            fldid = row.Slice(172, 4).BytesToLong();
            secfldid = row.Slice(176, 4).BytesToLong();
            associdx = row.Slice(180, 2).BytesToShort();
            typ = row.Slice(182, 2).BytesToShort();
            page = row.Slice(184, 2).BytesToShort();
            stcol = row.Slice(186, 2).BytesToShort();
            dcps = row.Slice(188, 2).BytesToShort();
            st = row.Slice(190, 2).BytesToShort();
            ln = row.Slice(192, 2).BytesToShort();
            rfile = new int[] { row.Slice(194, 2).BytesToShort(), row.Slice(196, 2).BytesToShort() };
            rindex = new int[] { row.Slice(198, 2).BytesToShort(), row.Slice(200, 2).BytesToShort() };
            rfld = new int[] { row.Slice(202, 2).BytesToShort(), row.Slice(204, 2).BytesToShort() };
            rdisp = new int[2, 4] {
                { row.Slice(206, 2).BytesToShort(), row.Slice(208, 2).BytesToShort(), row.Slice(210, 2).BytesToShort(), row.Slice(212, 2).BytesToShort() },
                { row.Slice(214, 2).BytesToShort(), row.Slice(216, 2).BytesToShort(), row.Slice(218, 2).BytesToShort(), row.Slice(220, 2).BytesToShort() }
            };
            rdisplen = new int[2, 4] {
                { row.Slice(222, 2).BytesToShort(), row.Slice(224, 2).BytesToShort(), row.Slice(226, 2).BytesToShort(), row.Slice(228, 2).BytesToShort() },
                { row.Slice(230, 2).BytesToShort(), row.Slice(232, 2).BytesToShort(), row.Slice(234, 2).BytesToShort(), row.Slice(236, 2).BytesToShort() }
            };
            drfld = new int[] { row.Slice(238, 2).BytesToShort(), row.Slice(240, 2).BytesToShort(), row.Slice(242, 2).BytesToShort(), row.Slice(244, 2).BytesToShort() };
            drfldto = new int[] { row.Slice(246, 2).BytesToShort(), row.Slice(248, 2).BytesToShort(), row.Slice(250, 2).BytesToShort(), row.Slice(252, 2).BytesToShort() };
            times = row.Slice(254, 2).BytesToShort();
            literaltop = row.Slice(256, 2).BytesToShort();
            fieldtop = row.Slice(258, 2).BytesToShort();
            literalleft = row.Slice(260, 2).BytesToShort();
            fieldleft = row.Slice(262, 2).BytesToShort();
            fieldheight = row.Slice(264, 2).BytesToShort();
            fieldwidth = row.Slice(266, 2).BytesToShort();
            w7tabindex = row.Slice(268, 2).BytesToShort();
            literalwidth = row.Slice(270, 2).BytesToShort();
            literalheight = row.Slice(272, 2).BytesToShort();
            shortenkey = row.Slice(274, 2).BytesToShort();
            startlen = row.Slice(276, 2).BytesToShort();
            oldfldno = row.Slice(278, 2).BytesToShort();
            currfldno = row.Slice(280, 2).BytesToShort();
            temp = row.Slice(282, 2).BytesToString();
            hidden = row.Slice(284, 1).BytesToString();
            joininrptandtrn = row.Slice(285, 1).BytesToString();
            parentscreen = row.Slice(286, 4).BytesToString();
            longliteral = row.Slice(290, 129).BytesToString();
            w7fieldtype = row.Slice(419, 1).BytesToString();
            fieldidkey = row.Slice(420, 4).BytesToString();
            fieldmask = row.Slice(424, 2).BytesToString();
            fieldfontsize = row.Slice(426, 2).BytesToString();
            fieldbold = row.Slice(428, 1).BytesToString();
            literalbold = row.Slice(429, 1).BytesToString();
            literalfontsize = row.Slice(430, 2).BytesToString();
            literalfont = row.Slice(432, 32).BytesToString();
            fieldfont = row.Slice(464, 32).BytesToString();
            wintypestr = row.Slice(496, 16).BytesToString();

        }
        
    }
}
