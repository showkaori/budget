using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;// MySQLを使用
using System.Collections.ObjectModel;


namespace Budget
{
     class SQL
    {
        // MySQLへの接続情報
        private static readonly string server = "localhost";
        private static readonly string database = "budget";//使用するデータベース
        private static readonly string MysqlTable = "expenditure";//使用するテーブル
        private static readonly string user = "root";//ユーザー名
        private static readonly string pass = "root";//インストール時に設定したパスワード
        private static readonly string charset = "utf8";
        // MySQLへの接続
        private static readonly string connectionString = string.Format("Server={0};Database={1};Uid={2};Pwd={3};Charset={4}", server, database, user, pass, charset);


        //【カテゴリー別のその月の合計金額取得】
        public List<string> GetSum()
        {
            //カテゴリー別の合計金額をリスト格納する箱を用意
            List<string> sum = new List<string>();
            try
            {
                // コネクションオブジェクトとコマンドオブジェクトの生成
                using (var connection = new MySqlConnection(connectionString))
                using (var command = new MySqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;

                    var categoryList = new string[] {"食費", "外食", "交通費", "日用品", "遊び", "洋服・美容", "教養", "家族", "家賃・住まい", "光熱費", "保険", "税金", "その他"};

                    for(var i = 0; i < categoryList.Length; i++)
                    {
                        //データ抽出用SQL
                        string thisMonth = DateTime.Now.ToString("yyyyMM");
                        string category = categoryList[i];
                        string SelectSql = $"SELECT IFNULL(SUM(money), '0') FROM {MysqlTable} WHERE MONTH = '{thisMonth}' AND CATEGORY = '{category}'";

                        command.CommandText = SelectSql;
                        //SQL実行し結果を格納
                        MySqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            sum.Add(reader.GetString(0));
                        }
                        reader.Close();
                    }
                   
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return sum;
        }

        //【データの追加】
        public void AddExp(DateTime day, string category, string detail, int money, string payment, string memo, string month)
        {
            try
            {
                // コネクションオブジェクトとコマンドオブジェクトの生成
                using (var connection = new MySqlConnection(connectionString))
                using (var command = new MySqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;

                    string InsertData = $"('{detail}', '{memo}', '{category}', {money}, '{payment}', '{day}', '{month}')";　//追加内容
                    //INSERT用SQL
                    string InsertTableSql = $"INSERT INTO {MysqlTable} (detail, memo, category, money, payment, day, month) VALUES {InsertData}";
                    command.CommandText = InsertTableSql;
                    command.ExecuteNonQuery(); //実行
                }

            }
            catch (Exception e2)
            {
                Console.WriteLine(e2.Message);

            }
        }

        //【出費一覧表示】
        internal List<Expenditure> GetAllList()
        {
            List<Expenditure> getAllList = new List<Expenditure>();
            try
            {
                // コネクションオブジェクトとコマンドオブジェクトの生成
                using (var connection = new MySqlConnection(connectionString))
                using (var command = new MySqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;

                    string SelectSql = $"SELECT * FROM {MysqlTable} ORDER BY day";
                    command.CommandText = SelectSql;
                    //SQL実行し結果を格納
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = int.Parse(reader.GetString(0));
                        string detail = reader.GetString(1);
                        string memo;
                        if (reader.GetString(2) == null)
                        { memo = "　"; }
                        else
                        { memo = reader.GetString(2); }
                        string category = reader.GetString(3);
                        int money = int.Parse(reader.GetString(4));
                        string payment = reader.GetString(5);
                        DateTime day = DateTime.Parse(reader.GetString(6));
                        string month = reader.GetString(7);
                        Expenditure exp = new Expenditure(id, detail, memo, category, money, payment, day, month);
                        getAllList.Add(exp);
                    }
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return getAllList;
        }

        //【カテゴリー別一覧表示】
        internal List<Expenditure> GetList(int num)
        {
            List<Expenditure> getList = new List<Expenditure>();
            try
            {
                // コネクションオブジェクトとコマンドオブジェクトの生成
                using (var connection = new MySqlConnection(connectionString))
                using (var command = new MySqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;

                    //カテゴリーの取得
                    var categoryList = new string[] { "食費", "外食", "交通費", "日用品", "遊び", "洋服・美容", "教養", "家族", "家賃・住まい", "光熱費", "保険", "税金", "その他" };
                    string SelectSql = $"SELECT * FROM {MysqlTable} WHERE CATEGORY = '{categoryList[(num - 1)]}' ORDER BY day";
                    command.CommandText = SelectSql;
                    //SQL実行し結果を格納
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = int.Parse(reader.GetString(0));
                        string detail = reader.GetString(1);
                        string memo;
                        if (reader.GetString(2) == null)
                        { memo = "　"; }
                        else
                        { memo = reader.GetString(2); }
                        string category = reader.GetString(3);
                        int money = int.Parse(reader.GetString(4));
                        string payment = reader.GetString(5);
                        DateTime day = DateTime.Parse(reader.GetString(6));
                        string month = reader.GetString(7);
                        Expenditure exp = new Expenditure(id, detail, memo, category, money, payment, day, month);
                        getList.Add(exp);
                    }
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return getList;
        }

        //データの編集
        internal void Update(string id, DateTime day, string category, string detail, string money, string payment, string memo, string month)
        {
            try
            {
                // コネクションオブジェクトとコマンドオブジェクトの生成
                using (var connection = new MySqlConnection(connectionString))
                using (var command = new MySqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    int id1 = int.Parse(id);
                    int money1 = int.Parse(money);
                    //INSERT用SQL
                    string UpdateSql = $"UPDATE {MysqlTable} SET detail = '{detail}', memo = '{memo}', category = '{category}', money = {money1}, payment = '{payment}', day = '{day}', month = '{month}' WHERE ID = {id1}";
                    command.CommandText = UpdateSql;
                    command.ExecuteNonQuery(); //実行
                }

            }
            catch (Exception e2)
            {
                Console.WriteLine(e2.Message);

            }
        }

        //【選択したデータの削除】
        internal void Delete(string id)
        {
            try
            {
                // コネクションオブジェクトとコマンドオブジェクトの生成
                using (var connection = new MySqlConnection(connectionString))
                using (var command = new MySqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;

                    //カテゴリーの取得
                    int id1 = int.Parse(id);
                    string DeleteSql = $"DELETE FROM {MysqlTable} WHERE ID = {id1}";
                    command.CommandText = DeleteSql;
                    command.ExecuteNonQuery();           //実行
                    Console.WriteLine($"【ID:{id}】のデータを消去しました。");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //【選択したデータの取得】
        internal Expenditure Select(string id)
        {
            Expenditure exp = null;
            try
            {
                // コネクションオブジェクトとコマンドオブジェクトの生成
                using (var connection = new MySqlConnection(connectionString))
                using (var command = new MySqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;

                    //カテゴリーの取得
                    int id1 = int.Parse(id);
                    string SelectSql = $"SELECT * FROM {MysqlTable} WHERE ID = {id1}";
                    command.CommandText = SelectSql;
                    //SQL実行し結果を格納
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id2 = int.Parse(reader.GetString(0));
                        string detail = reader.GetString(1);
                        string memo;
                        if (reader.GetString(2) == null)
                        { memo = "　"; }
                        else
                        { memo = reader.GetString(2); }
                        string category = reader.GetString(3);
                        int money = int.Parse(reader.GetString(4));
                        string payment = reader.GetString(5);
                        DateTime day = DateTime.Parse(reader.GetString(6));
                        string month = reader.GetString(7);
                        exp = new Expenditure(id2, detail, memo, category, money, payment, day, month);
                    }
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return exp;
        }


    }
}
