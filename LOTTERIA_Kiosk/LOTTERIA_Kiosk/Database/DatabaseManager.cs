﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOTTERIA_Kiosk.Database
{
    public class DatabaseManager
    {
        string connStr = "Server=10.80.161.63;Database=LOTTERIA;Uid=root;Pwd=5754";

        public bool isAutoLogin()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT * FROM isAutoLogin";

                //ExecuteReader를 이용하여
                //연결 모드로 데이타 가져오기
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if ("1".Equals(rdr["isAutoLogin"].ToString()))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                rdr.Close();
                return false;
            }
        }
    }
}
