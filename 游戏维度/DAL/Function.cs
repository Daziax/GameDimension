using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
namespace DAL
{
    public class Function
    {
        private static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
        string aspx = HttpContext.Current.Request.Url.ToString().Substring(23);
        public Manager SelectManager(string MID)
        {
            Manager manager = new Manager();
            SqlCommand com = new SqlCommand();
            SqlParameter parameter = new SqlParameter("@mID", MID);
            com.Connection = con;
            com.Parameters.Add(parameter);
            try
            {
                con.Open();
                com.CommandText = "Select * from Manager where mID = @mID";
                SqlDataReader read = com.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        manager.MID = read[0].ToString();
                        manager.MPsw = read[1].ToString();
                    }
                }
                else
                    HttpContext.Current.Response.Write("<script>alert('请检查账号是否正确！');window.location='" + aspx + "'</script>");

            }
            catch (SqlException ex)
            {
                HttpContext.Current.Response.Write("<script>alert('警告！ + " + ex.Message + "');window.location='" + aspx + "'</script>");
            }
            finally
            {
                con.Close();
            }
            return manager;
        }
        public void UpdateManager(string MID, string MPsw)
        {
            SqlCommand com = new SqlCommand();
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@mID",MID),new SqlParameter("@mPsw",MPsw)
            };
            com.Connection = con;
            com.Parameters.AddRange(parameter);
            try
            {
                con.Open();
                com.CommandText = "Update Manager set mPsw = '@mPsw' where mID = @mID";
                com.ExecuteReader();
            }
            catch (SqlException ex)
            {
                HttpContext.Current.Response.Write("<script>alert('警告！+" + ex.Message + "');window.location='" + aspx + "'</script>");
            }
            finally
            {
                con.Close();
            }
        }
        public void DeleteManager(string MID)
        {
            SqlParameter parameter = new SqlParameter("@mID", MID);
            SqlCommand com = new SqlCommand("DELETE FROM Manager WHERE mID =@mID", con);
            com.Parameters.Add(parameter);
            try
            {
                con.Open();
                com.ExecuteReader();
            }
            catch (SqlException ex)
            {
                HttpContext.Current.Response.Write("<script>alert('警告！+" + ex.Message + "');window.location='" + aspx + "'</script>");
            }
            finally
            {
                con.Close();
            }
        }
        public void InsertManager(string MID, string MPsw)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@mID",MID),new SqlParameter("@mPsw",MPsw)
            };
            SqlCommand com = new SqlCommand("INSERT INTO Manager (mID,mPsw) VALUES(@mID,'@mPsw')", con);
            com.Parameters.AddRange(parameter);
            try
            {
                con.Open();
                com.ExecuteReader();
            }
            catch (SqlException ex)
            {
                HttpContext.Current.Response.Write("<script>alert('警告！+" + ex.Message + "');window.location='" + aspx + "'</script>");
            }
            finally
            {
                con.Close();
            }
        }

        public UserPlayer SelectUser(string UIDorUPhone)
        {
            UserPlayer user = new UserPlayer();
            SqlCommand com;
            SqlParameter parameter;
            if (UIDorUPhone.Trim().Count() == 11 && UIDorUPhone.Trim().ToCharArray()[0] == '1')
            {
                parameter = new SqlParameter("@uPhone", SqlDbType.VarChar);
                com = new SqlCommand("Select * from UserPlayer where uPhone = @uPhone", con);
            }
            else
            {
                parameter = new SqlParameter("@uID", SqlDbType.VarChar);
                com = new SqlCommand("Select * from UserPlayer where uID = @uID", con);
            }
            parameter.Value = UIDorUPhone;
            com.Parameters.Add(parameter);
            try
            {
                con.Open();
                SqlDataReader read = com.ExecuteReader(CommandBehavior.CloseConnection);
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        user.UID = read[0].ToString();
                        user.UPsw = read[1].ToString();
                        user.USex = read[2].ToString();
                        user.UEditor = (read[3].ToString() == "1" ? true : false);
                        user.UName = read[4].ToString();
                        user.UNickname = read[5].ToString();
                        user.UPhone = read[6].ToString();
                        user.UPhoto = read[7].ToString();
                        user.UAddress = read[8].ToString();
                    }
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>alert('账号或密码出错！');window.location='" + aspx + "'</script>");
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("<script>alert('警告！ + " + ex.Message + "');window.location='" + aspx + "'</script>");
            }
            finally
            {
                con.Close();

            }
            return user;
        }
        public void UpdateUser(string UID, string USex, bool UEditor, string UName = "", string UNickname = "", string UPhoto = "", string UAddress = "")
        {
            SqlParameter[] parameter = new SqlParameter[]
           {
                new SqlParameter("@uID",SqlDbType.VarChar),new SqlParameter("@uSex",SqlDbType.VarChar),new SqlParameter("@uEditor", SqlDbType.Bit),new SqlParameter("@uName",SqlDbType.VarChar),
                new SqlParameter("@uNickname",SqlDbType.VarChar),new SqlParameter("@uPhoto",SqlDbType.VarChar),new SqlParameter("@uAddress",SqlDbType.NChar)
           };
            //new SqlParameter("@uPsw", SqlDbType.VarChar),new SqlParameter("@uPhone",SqlDbType.VarChar)
            SqlCommand com = new SqlCommand("UPDATE UserPlayer Set uSex=@uSex, uEditor=@uEditor, uName=@uName, uNickname=@uNickname, uPhoto=@uPhoto,uAddress=@uAddress WHERE uID=@UID", con);
            parameter[0].Value = UID;
            //parameter[1].Value = UPsw;
            parameter[1].Value = USex;
            parameter[2].Value = UEditor;
            parameter[3].Value = UName;
            parameter[4].Value = UNickname;
            parameter[5].Value = UPhoto;
            parameter[6].Value = UAddress;
            //parameter[6].Value = UPhone;
            
            com.Parameters.AddRange(parameter);
            try
            {
                con.Open();
                if(com.ExecuteNonQuery() > 0)
                    HttpContext.Current.Response.Write("<script>alert('成功修改');window.location='个人中心.aspx';</script>");
                else
                    HttpContext.Current.Response.Write("<script>alert('警告！修改失败');window.location='个人中心.aspx';</script>");

            }
            catch (SqlException ex)
            {
                //HttpContext.Current.Response.Write("<script>alert('警告！" + ex.Message + "');window.location='个人中心.aspx';</script>");
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        //public void UpdateUser(string UID, string UPsw, string USex, bool UEditor, string UName = "", string UNickname = "", string UPhone = "", string UPhoto = "")
        //{
        //    SqlParameter[] parameter = new SqlParameter[]
        //   {
        //        new SqlParameter("@uID",SqlDbType.VarChar),new SqlParameter("@uPsw",SqlDbType.VarChar),new SqlParameter("@uSex",SqlDbType.VarChar),new SqlParameter("@uEditor", SqlDbType.Bit),new SqlParameter("@uName",SqlDbType.VarChar),
        //        new SqlParameter("@uNickname",SqlDbType.VarChar),new SqlParameter("@uPhone",SqlDbType.VarChar),new SqlParameter("@uPhoto",SqlDbType.VarChar)
        //   };
        //    SqlCommand com = new SqlCommand("UPDATE UserPlayer Set uID=@uID, uPsw=@Psw,uSex=@uSex, uEditor=@uEditor, uName=@uName, uNickname=@uNickname, uPhone=@uPhone, uPhoto=@uPhoto", con);
        //    parameter[0].Value = UID;
        //    parameter[1].Value = UPsw;
        //    parameter[2].Value = USex;
        //    parameter[3].Value = UEditor;
        //    parameter[4].Value = UName;
        //    parameter[5].Value = UNickname;
        //    parameter[6].Value = UPhone;
        //    parameter[7].Value = UPhoto;
        //    com.Parameters.AddRange(parameter);
        //    try
        //    {
        //        con.Open();
        //        com.ExecuteReader();

        //    }
        //    catch (SqlException ex)
        //    {
        //        HttpContext.Current.Response.Write("<script>alert('警告！+" + ex.Message + "');window.location='个人中心.aspx';</script>");

        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}
        public void UpdateUser1(string UID, string column, string newcontent)
        {

            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@uID",SqlDbType.VarChar),new SqlParameter("@new",SqlDbType.VarChar)
            };
            parameter[0].Value = UID;
            parameter[1].Value = newcontent;
            SqlCommand com = new SqlCommand();
            com = new SqlCommand(String.Format("UPDATE UserPlayer set {0} = @new where uID = @uID",column), con);
            com.Parameters.AddRange(parameter);
            try
            {
                con.Open();
                if (com.ExecuteNonQuery() > 0)
                    HttpContext.Current.Response.Write("<script>alert('成功修改');window.location='个人中心.aspx';</script>");
                else
                    HttpContext.Current.Response.Write("<script>alert('警告！修改失败');window.location='个人中心.aspx';</script>");
            }
            catch (SqlException ex)
            {
                throw ex;
                //HttpContext.Current.Response.Write("<script>alert('警告！" + ex.Message + "');window.location='个人中心.aspx'</script>");
            }
            finally
            {
                con.Close();
            }
        }
        public void DeleteUser(string UID)
        {
            SqlParameter parameter = new SqlParameter("@uID", UID);
            SqlCommand com = new SqlCommand("DELETE FROM UserPlayer WHERE uID =@uID", con);
            com.Parameters.Add(parameter);
            try
            {
                con.Open();
                com.ExecuteReader();
            }
            catch (SqlException ex)
            {
                HttpContext.Current.Response.Write("<script>alert('警告！+" + ex.Message + "');window.location='" + aspx + "'</script>");
            }
            finally
            {
                con.Close();
            }
        }
        public bool InsertUser(string UID, string UPsw, string USex, bool UEditor, string UName = "", string UNickname = "", string UPhone = "", string UPhoto = "",string UAddress="")
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@uID",SqlDbType.VarChar),new SqlParameter("@uPsw",SqlDbType.VarChar),new SqlParameter("@uSex",SqlDbType.VarChar),new SqlParameter("@uEditor", SqlDbType.Bit),new SqlParameter("@uName",SqlDbType.VarChar),
                new SqlParameter("@uNickname",SqlDbType.VarChar),new SqlParameter("@uPhone",SqlDbType.VarChar),new SqlParameter("@uPhoto",SqlDbType.VarChar),new SqlParameter("@uAddress",SqlDbType.NChar)
            };
            SqlCommand com = new SqlCommand("INSERT INTO UserPlayer (uID, uPsw,uSex, uEditor, uName, uNickname, uPhone, uPhoto,uAddress) VALUES(@uID,@uPsw,@uSex,@uEditor,@uName,@uNickname,@uPhone,@uPhoto,@uAddress)", con);
            parameter[0].Value = UID;
            parameter[1].Value = UPsw;
            parameter[2].Value = USex;
            parameter[3].Value = UEditor; 
            parameter[4].Value = UName;
            parameter[5].Value = UNickname;
            parameter[6].Value = UPhone;
            parameter[7].Value = UPhoto;
            parameter[8].Value = UAddress;
            com.Parameters.AddRange(parameter);
            try
            {
                con.Open();
                com.ExecuteReader();
                return true;
            }
            catch (SqlException ex)
            {
                HttpContext.Current.Response.Write("<script>alert('警告！+" + ex.Message + "');window.location='个人中心.aspx';</script>");
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public Gamelist SelectGamelist(string GName)
        {
            Gamelist gamelist = new Gamelist();
            SqlParameter parameter = new SqlParameter("@gName", GName);
            SqlCommand com = new SqlCommand("Select * from Gamelist where gName = @gName", con);
            com.Parameters.Add(parameter);
            try
            {
                con.Open();
                SqlDataReader read = com.ExecuteReader(CommandBehavior.CloseConnection);
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        gamelist.GName = read[0].ToString();
                        gamelist.GInformation = read[1].ToString();
                        gamelist.GPrice = read[2].ToString();
                        gamelist.GStation = read[3].ToString();
                        gamelist.GImage = read[4].ToString();
                        gamelist.GVideo = read[5].ToString().Replace("\\", "/");
                        gamelist.GWhere = read[6].ToString();
                        gamelist.GInventory = read[7].ToString();
                        gamelist.GSold = read[8].ToString();
                        gamelist.GPreturn = read[9].ToString();
                        gamelist.GReturn = read[10].ToString();
                    }
                }
            }
            catch (SqlException ex)
            {
                HttpContext.Current.Response.Write("<script>alert('警告！+" + ex.Message + "');window.location='" + aspx + "'</script>");
            }
            finally
            {
                con.Close();
            }
            return gamelist;
        }
        public DataTable AllSelectGamelist()
        {
            DataTable dt = new DataTable();
            SqlCommand com = new SqlCommand("Select * from Gamelist", con);
            try
            {
                con.Open();
                SqlDataReader read = com.ExecuteReader(CommandBehavior.CloseConnection);
                if (read.HasRows)
                {
                    dt.Load(read);
                }
            }
            catch (SqlException ex)
            {
                HttpContext.Current.Response.Write("<script>alert('警告！+" + ex.Message + "');window.location='" + aspx + "'</script>");
            }
            finally
            {
                con.Close();
            }
            return dt;
        }
        public DataTable ManagerSelectGamelist()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds.Tables.Add(dt);
            SqlCommand com = new SqlCommand("Select * from gamelist", con);
            try
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                con.Open();
                SqlDataReader read = com.ExecuteReader(CommandBehavior.CloseConnection);
                ds.Tables[0].Load(read);
                return ds.Tables[0];
            }
            catch (SqlException ex)
            {
                HttpContext.Current.Response.Write("<script>alert('警告！+" + ex.Message + "');window.location='" + aspx + "'</script>");
                return ds.Tables[0];
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateGamelist1(string GName, string column, string newcontent)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@gName",SqlDbType.NVarChar),new SqlParameter("@new",SqlDbType.VarChar)
            };
            parameter[0].Value = GName;
            parameter[1].Value = newcontent;
            SqlCommand com = new SqlCommand(string.Format("UPDATE Gamelist SET {0} = @new where gName= @gName",column), con);
            com.Parameters.AddRange(parameter);      
            try
            {
                con.Open();
                com.ExecuteReader();
            }
            catch (SqlException ex)
            {
                throw ex;

            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateGamelist(string GName, string GImage, string GPrice, string GInformation, string GVideo)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@gImage",SqlDbType.VarChar),new SqlParameter("@gInformation",SqlDbType.NVarChar),
                new SqlParameter("@gVideo",SqlDbType.VarChar), new SqlParameter("@gPrice",SqlDbType.VarChar),new SqlParameter("@gName",SqlDbType.NVarChar)
            };
            parameter[0].Value = GImage;
            parameter[1].Value = GInformation;
            parameter[2].Value = GVideo;
            parameter[3].Value = GPrice;
            parameter[4].Value = GName;
            SqlCommand com = new SqlCommand("UPDATE Gamelist SET gImage = @gImage,gInformation=@gInformation,gVideo=@gVideo,gPrice=@gPrice where gName= @gName", con);
            com.Parameters.AddRange(parameter);
            try
            {
                con.Open();
                com.ExecuteReader();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("<script>alert('警告！+" + ex.Message + "');window.location='" + aspx + "'</script>");
            }
            finally
            {
                con.Close();
            }
        }
        public void DeleteGamelist(System.Web.UI.WebControls.GridView gv, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            SqlParameter parameter = new SqlParameter("@gName", gv.DataKeys[e.RowIndex].Value.ToString());
            SqlCommand com = new SqlCommand("delete from Gamelist where gName=@gName", con);
            com.Parameters.Add(parameter);
            try
            {
                con.Open();
                if (com.ExecuteNonQuery() > 0)
                {
                    HttpContext.Current.Response.Write("<script>alert('删除成功');window.location='" + aspx + "'</script>");
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>alert('删除失败');window.location='" + aspx + "'</script>");
                }
            }
            catch (SqlException ex)
            {
                HttpContext.Current.Response.Write("<script>alert('警告！+" + ex.Message + "');window.location='" + aspx + "'</script>");
            }
            finally
            {
                con.Close();
            }
        }
        public void DeleteGamelist1(string Gname)
        {
            SqlParameter parameter = new SqlParameter("@gName", Gname);
            SqlCommand com = new SqlCommand("DELETE FROM Gamelist WHERE gName =@gName", con);
            com.Parameters.Add(parameter);
            try
            {
                con.Open();
                com.ExecuteReader();
            }
            catch (SqlException ex)
            {
                HttpContext.Current.Response.Write("<script>alert('警告！+" + ex.Message + "');window.location='" + aspx + "'</script>");
            }
            finally
            {
                con.Close();
            }
        }
        public void InsertGamelist(string GName, string GInformation, string GPrice, string GImage, string GVideo, string GStation = "", string GWhere = "")
        {
            SqlParameter[] parameter = new SqlParameter[]
                        {
                new SqlParameter("@gImage",SqlDbType.VarChar),new SqlParameter("@gInformation",SqlDbType.NVarChar),
                new SqlParameter("@gVideo",SqlDbType.VarChar), new SqlParameter("@gPrice",SqlDbType.VarChar),
                new SqlParameter("@gName",SqlDbType.NVarChar),

                        };
            parameter[0].Value = GImage;
            parameter[1].Value = GInformation;
            parameter[2].Value = GVideo;
            parameter[3].Value = GPrice;
            parameter[4].Value = GName;

            SqlCommand com = new SqlCommand("INSERT INTO Gamelist (gName,gInformation,gPrice,gImage,gVideo,gPreturn,gReturn,gSold,gInventory) VALUES(@gName,@gInformation,@gPrice,@gImage,@gVideo,0,0,0,0)", con);
            com.Parameters.AddRange(parameter);
            try
            {
                con.Open();
                if (com.ExecuteNonQuery() > 0)
                {
                    HttpContext.Current.Response.Write("<script>alert('添加成功');window.location='游戏管理.aspx'</script>");
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>alert('添加失败');window.location='游戏管理.aspx'</script>");
                }
            }
            finally
            {
                con.Close();
            }




        }

        public Comment SelectComment(string CGamename)
        {
            Comment comment = new Comment();
            SqlParameter parameter = new SqlParameter("@cGamename", CGamename);
            SqlCommand com = new SqlCommand("Select * from Comment where cGamename = @cGamename", con);
            com.Parameters.Add(parameter);
            try
            {
                con.Open();
                SqlDataReader read = com.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        comment.CGamename = read[0].ToString();
                        comment.CID = read[1].ToString();
                        comment.CUserID = read[2].ToString();
                        comment.CScore = Convert.ToInt16(read[3]);
                        comment.CContent = read[4].ToString();
                        comment.CIsReply = (read[5].ToString() == "1" ? true : false);
                    }
                }
            }
            catch (SqlException ex)
            {
                HttpContext.Current.Response.Write("<script>alert('警告！+" + ex.Message + "');window.location='" + aspx + "'</script>");
            }
            finally
            {
                con.Close();
            }
            return comment;
        }
        public void UpdateComment(string CGamename, string column, string newcontent)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@cGamename",CGamename),new SqlParameter("@column",column),new SqlParameter("@new",newcontent)
            };
            SqlCommand com = new SqlCommand();
            if (column != "cScore" || column != "cIsReply")
                com = new SqlCommand("Update Comment set @column = '@new' where cGamename = @cGamename", con);
            else if (column == "cScore" || column == "cIsReply")
                com = new SqlCommand("Update Comment set @column = @new where cGamename = @cGamename", con);

            com.Connection = con;
            com.Parameters.AddRange(parameter);
            try
            {
                con.Open();
                com.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (SqlException ex)
            {
                HttpContext.Current.Response.Write("<script>alert('警告！+" + ex.Message + "');window.location='" + aspx + "'</script>");
            }
            finally
            {
                con.Close();
            }
        }
        public void DeleteComment(string CGamename)
        {
            SqlParameter parameter = new SqlParameter("@cGamename", CGamename);
            SqlCommand com = new SqlCommand("DELETE FROM Comment WHERE cGamename =@cGamename", con);
            com.Parameters.Add(parameter);
            try
            {
                con.Open();
                com.ExecuteReader();
            }
            catch (SqlException ex)
            {
                HttpContext.Current.Response.Write("<script>alert('警告！+" + ex.Message + "');window.location='" + aspx + "'</script>");
            }
            finally
            {
                con.Close();
            }
        }
        public void InsertComment(string CGamename, string CInformation, string CUserID, int CScore, string CContent, bool CIsReply)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@cGamename",CGamename),new SqlParameter("@cInformation",CInformation),new SqlParameter("@cUserID",CUserID),new SqlParameter("@cScore",CScore),new SqlParameter("@cContent",CContent),
                new SqlParameter("@cIsReply",CIsReply)
            };
            SqlCommand com = new SqlCommand("INSERT INTO User (cGamename,cInformation,cUserID,cScore,cContent,cIsReply) VALUES('@cGamename','@cInformation','@cUserID',cScore,'@cContent',cIsReply)", con);
            com.Parameters.AddRange(parameter);
            try
            {
                con.Open();
                com.ExecuteReader();
            }
            catch (SqlException ex)
            {
                HttpContext.Current.Response.Write("<script>alert('警告！+" + ex.Message + "');window.location='" + aspx + "'</script>");
            }
            finally
            {
                con.Close();
            }
        }

        //操作MyGame
        public DataTable SelectMyGame(string UID)
        {
            DataTable tb = new DataTable();
            SqlParameter parameter = new SqlParameter("@uID", UID);
            SqlCommand com = new SqlCommand("SELECT gName,gImage,gPrice FROM Gamelist where gName in (Select gName from MyGame where uID = @uID)", con);
            com.Parameters.Add(parameter);
            try
            {

                con.Open();
                SqlDataReader read = com.ExecuteReader();
                tb.Load(read);
                return tb;
            }
            catch (SqlException ex)
            {
                HttpContext.Current.Response.Write("<script>alert('警告！" + ex.Message.ToString() + "');window.location='" + aspx + "'</script>");
                return tb;
            }
            finally
            {
                con.Close();
            }
        }
        public void InsertMyGame(string GName, string UID)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@gName",GName),new SqlParameter("@uID",UID)
            };
            SqlCommand com = new SqlCommand("INSERT INTO MyGame (uID,gName) VALUES(@uID,@gName)", con);
            com.Parameters.AddRange(parameter);
            try
            {
                con.Open();
                com.ExecuteReader();
            }
            catch (SqlException ex)
            {
                HttpContext.Current.Response.Write("<script>alert('警告！+" + ex.Message + "');window.location='" + aspx + "'</script>");
            }
            finally
            {
                con.Close();
            }
        }

        //操作MyOrder
        public DataTable SelectMyOrder(string UID)
        {
            DataTable tb = new DataTable();
            SqlParameter parameter = new SqlParameter("@moUID", UID);
            SqlCommand com = new SqlCommand("SELECT moName,moTime,moAmount,moPrcie,moStatus FROM MyOrder where moUID=@moUID", con);
            com.Parameters.Add(parameter);
            try
            {

                con.Open();
                SqlDataReader read = com.ExecuteReader();
                tb.Load(read);
                return tb;
            }
            catch (SqlException ex)
            {
                HttpContext.Current.Response.Write("<script>alert('警告！" + ex.Message.ToString() + "');window.location='" + aspx + "'</script>");
                return tb;
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateMyOrder(string column, string newStatus,DateTime uniqTime,string uniqUID)
        {
            SqlParameter[] parameter = new SqlParameter[]
            {
               new SqlParameter("@new",SqlDbType.VarChar),new SqlParameter("@moTime",SqlDbType.DateTime),new SqlParameter("@moUID",SqlDbType.VarChar)
            };
            
            parameter[0].Value = newStatus;
            parameter[1].Value = uniqTime;
            parameter[2].Value = uniqUID;
            SqlCommand com = new SqlCommand(string.Format("UPDATE MyOrder SET {0} = @new where moUID=@moUID AND moTime=@moTime", column), con);
            com.Parameters.AddRange(parameter);
            try
            {
                con.Open();
                if(com.ExecuteNonQuery() == 0)
                    HttpContext.Current.Response.Write("<script>alert('db失败');</script>");

            }
            catch (SqlException ex)
            {
                throw ex;

            }
            finally
            {
                con.Close();
            }
        }
        public void InsertMyOrder(string MOName, string MOPrice, string MOUID,string Amount,string Form)
        {


            DateTime MOTime = DateTime.Now;
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@moName",SqlDbType.NVarChar),new SqlParameter("@moUID",SqlDbType.VarChar),
                new SqlParameter("@moAmount",SqlDbType.VarChar),new SqlParameter("@moPrice",SqlDbType.VarChar),
                new SqlParameter("@moStatus",SqlDbType.NVarChar),new SqlParameter("@moTime",SqlDbType.DateTime),
                new SqlParameter("@moForm",SqlDbType.NChar)
            };
            SqlCommand com = new SqlCommand("INSERT INTO MyOrder (moName,moTime,moAmount,moPrice,moStatus,moUID,moForm) VALUES(@moName,@moTime,@moAmount,@moPrice,@moStatus,@moUID,@moForm)", con);
            parameter[0].Value = MOName.Trim();
            parameter[1].Value = MOUID.Trim();
            parameter[2].Value = Amount;
            parameter[3].Value = MOPrice;
            parameter[4].Value = "交易中";
            parameter[5].Value = MOTime;
            parameter[6].Value = Form;
            com.Parameters.AddRange(parameter);
            try
            {
                con.Open();
                com.ExecuteReader();
                HttpContext.Current.Response.Write("<script>alert('购买完成！');window.location='" + aspx + "'</script>");
            }
            catch (SqlException ex)
            {
                HttpContext.Current.Response.Write("<script>alert('警告！:" + ex.Message + "');window.location='" + aspx + "'</script>");
            }
            finally
            {
                con.Close();
            }
        }

        public void InsertOrderRecord(string ORName,string ORAmount,string ORPrice,string ORForm)
        {
            DateTime ORTime = DateTime.Now;
            SqlParameter[] parameter = new SqlParameter[]
            {
                new SqlParameter("@orName",SqlDbType.NVarChar),new SqlParameter("@orAmount",SqlDbType.VarChar),
                new SqlParameter("@orPrice",SqlDbType.VarChar),new SqlParameter("@orForm",SqlDbType.VarChar),
                new SqlParameter("@orTime",SqlDbType.DateTime),new SqlParameter("@orUnitPrice",SqlDbType.VarChar),
            };
           /*SqlParameter[] parameters1 = new SqlParameter[]
            {
                new SqlParameter("@gInventory", gm.GInformation + ORAmount),
                new SqlParameter("@gName",ORName),
            };*/
            SqlCommand com = new SqlCommand("INSERT INTO OrderRecord (orName,orTime,orAmount,orPrice,orForm,orUnitPrice) VALUES(@orName,@orTime,@orAmount,@orPrice,@orForm,@orUnitPrice)", con);
           // SqlCommand com1 = new SqlCommand("UPDATE Gamelist SET gInventory=@gInventory WHERE gName=@gName", con);//更改游戏库存数量
            parameter[0].Value = ORName.Trim();
            parameter[1].Value = ORAmount.Trim();
            parameter[2].Value = ORPrice;
            parameter[3].Value = ORForm;
            parameter[4].Value = ORTime;
            parameter[5].Value = (Convert.ToInt32(ORPrice) / Convert.ToInt32(ORAmount)).ToString();
            com.Parameters.AddRange(parameter);
            //com1.Parameters.AddRange(parameters1);
            try
            {
                con.Open();
                com.ExecuteReader();
                //com1.ExecuteReader();
                HttpContext.Current.Response.Write("<script>alert('进货添加完成');window.location='" + aspx + "'</script>");
            }
            catch (SqlException ex)
            {
                HttpContext.Current.Response.Write("<script>alert('警告！+" + ex.Message + "');</script>");
            }
            finally
            {
                con.Close();
            }
        }

    }
}
