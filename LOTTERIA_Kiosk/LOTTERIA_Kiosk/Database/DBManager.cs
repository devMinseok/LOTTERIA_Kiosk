using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOTTERIA_Kiosk.Database
{
    class DBManager
    {
        string connStr = "Server=localhost;Port=3306;Database=LOTTERIA;Uid=root;Pwd=5754";

        public bool isAutoLogin()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM isAutoLogin";

                    //ExecuteReader를 이용하여
                    //연결 모드로 데이타 가져오기
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        if ("1".Equals(rdr["id"].ToString()))
                        {
                            if ("1".Equals(rdr["isAutoLogin"].ToString()))
                            {
                                return true;
                            } else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    rdr.Close();
                    conn.Close();
                }
                catch
                {
                    return false;
                }
                               
                return false;
            }
        }

        public List<string> getBarcodeList()
        {
            List<string> barcodeList = new List<string>();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT * FROM User";

                    //ExecuteReader를 이용하여
                    //연결 모드로 데이타 가져오기
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        barcodeList.Add(rdr["barcode"].ToString());
                    }
                    rdr.Close();
                    conn.Close();
                }
                catch
                {
                    
                }

                return barcodeList;
            }
        }


    }
}
