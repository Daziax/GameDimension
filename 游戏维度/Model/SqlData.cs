using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Model
{
    class SqlData
    {
    }
    public class Manager
    {
        public string MID { get; set; }
        public string MPsw { get; set; }
    }
    public class UserPlayer
    {
        private string uID;
        private string uPsw;
        private string uSex;
        private bool uEditor;
        private string uName;
        private string uNickname;
        private string uPhone;
        private string uPhoto;
        private string uAddress;

        public string UID { get => uID; set => uID = value; }
        public string UPsw { get => uPsw; set => uPsw = value; }
        public string USex { get => uSex; set => uSex = value; }
        public bool UEditor { get => uEditor; set => uEditor = value; }
        public string UName { get => uName; set => uName = value; }
        public string UNickname { get => uNickname; set => uNickname = value; }
        public string UPhone { get => uPhone; set => uPhone = value; }
        public string UPhoto { get => uPhoto; set => uPhoto = value; }

        public string UAddress { get => uAddress; set => uAddress = value; }
    }
    public class Gamelist
    {
        private string gName;
        private string gInformation;
        private string gPrice;
        private string gStation;
        private string gImage;
        private string gVideo;
        private string gWhere;

        public string GName { get => gName; set => gName = value; }
        public string GInformation { get => gInformation; set => gInformation = value; }
        public string GPrice { get => gPrice; set => gPrice = value; }
        public string GStation { get => gStation; set => gStation = value; }
        public string GImage { get => gImage; set => gImage = value; }
        public string GVideo { get => gVideo; set => gVideo = value; }
        public string GWhere { get => gWhere; set => gWhere = value; }

        public string GInventory { get; set; }
        public string GSold { get; set; }
        public string GPreturn { get; set; }
        public string GReturn { get; set; }
    }
    public class Comment
    {
        private string cGamename;
        private string cID;
        private string cUserID;
        private Int16 cScore;
        private string cContent;
        private bool cIsReply;

        public string CGamename { get => cGamename; set => cGamename = value; }
        public string CID { get => cID; set => cID = value; }
        public string CUserID { get => cUserID; set => cUserID = value; }
        public Int16 CScore { get => cScore; set => cScore = value; }
        public string CContent { get => cContent; set => cContent = value; }
        public bool CIsReply { get => cIsReply; set => cIsReply = value; }
    }
    public class MyGame
    {
        public string MID { get; set; }
        public string MName { get; set; }

    }

    public class MyOrder
    {
        public static string moName;
        public static DateTime moTime;
        public static string moAmount;
        public static string moStatus;
        public static string moPrice;
        public static string moCompany;
        public static string moTracking;
        public static string moKey;
        public static string moUID;
        public string MOName { get ; set; }
        public DateTime MOTime { get ; set ; }
        public string MOAmount { get; set; }
        public string MOStatus { get; set; }
        public string MOPrice { get; set; }
        public string MOCompany { get; set; }
        public string MOTracking { get; set; }
        public string MOKey { get; set; }
        public string MOUID { get; set; }

    }
    public class Pass
    {
       public int Row { get; set; }
    }
    public class SCart
    {
        public static string scName;
        public static DateTime scTime;
        public static string scAmount;
        public static string scStatus;
        public static string scPrice;
        public static string scUID;

        public static string scName1;
        public static DateTime scTime1;
        public static string scAmount1;
        public static string scStatus1;
        public static string scPrice1;
        public static string scUID1;
    }

}
