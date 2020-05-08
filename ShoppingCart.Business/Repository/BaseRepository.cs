using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ShoppingCart.Business.Log;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;
using Dapper;
using System.Transactions;

namespace ShoppingCart.Business.Repository
{
    public abstract class BaseRepository<T> where T : class
    {
        protected IDbConnection Connection { get; }

        public abstract string Table { get; }

        public BaseRepository()
        {

            Connection = new SqlConnection(ConfigurationManager.AppSettings["GroceryDB"]);
        }

        public List<T> GetAll()
        {
            string query = $"SELECT * FROM {Table}";

            try
            {
                return Connection.Query<T>(query).ToList();
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex.StackTrace);
                return new List<T>();
            }
        }

        public bool Add(T data)
        {
            try
            {
                List<string> fieldList = new List<string>();
                List<string> valueList = new List<string>();
                PropertyInfo[] properties = typeof(T).GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    fieldList.Add(property.Name);
                    valueList.Add($"@{property.Name}");
                }

                string field = string.Join(", ", fieldList);
                string value = string.Join(", ", valueList);

                string query = $"INSERT INTO {Table} ({field}) VALUES ({value})";

                return Connection.Execute(query, data) == 1;
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex.StackTrace);
                return false;
            }
        }

        public T GetById(int id)
        {
            try
            {
                PropertyInfo[] properties = typeof(T).GetProperties();

                string query = $"SELECT * FROM {Table} WHERE Id=@Id";

                return Connection.Query<T>(query, new { Id = id }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex.StackTrace);
                return null;
            }
        }

        public List<T> GetAllWhere(T data, string condition)
        {
            try
            {
                PropertyInfo[] properties = typeof(T).GetProperties();

                string query = $"SELECT * FROM {Table} WHERE {condition}";

                return Connection.Query<T>(query, data).ToList();
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex.StackTrace);
                return null;
            }
        }

        public bool Update(T data)
        {
            try
            {
                List<string> fieldList = new List<string>();
                PropertyInfo[] properties = typeof(T).GetProperties();

                string condition = $"{properties[0].Name}=@{properties[0].Name}";

                foreach (PropertyInfo property in properties.Skip(1))
                {
                    fieldList.Add($"{property.Name} = @{property.Name}");
                }

                string field = string.Join(", ", fieldList);

                string query = $"UPDATE {Table} SET {field} WHERE {condition}";

                return Connection.Execute(query, data) > 0;
                
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex.StackTrace);
                return false;
            }
        }

        public bool Delete(List<T> datas, string condition)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (T data in datas)
                    {
                        PropertyInfo[] properties = typeof(T).GetProperties();

                        string query = $"DELETE FROM {Table} WHERE {condition}";
                        int count = Connection.Execute(query, data);

                        if (count <= 0)
                        {
                            return false;
                        }
                    }

                    scope.Complete();
                }

                return true;
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex.StackTrace);
                return false;
            }
        }
    }
}
