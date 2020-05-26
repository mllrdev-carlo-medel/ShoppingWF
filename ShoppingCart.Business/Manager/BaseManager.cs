﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ShoppingCart.Business.Repository.Interfaces;

namespace ShoppingCart.Business.Manager
{
    public abstract class BaseManager<T> where T : class
    {
        public abstract IRepository<T> Repository { get; }

        public int Add(T data)
        {
            return Repository.Add(data);
        }

        public bool Delete(List<T> datas)
        {
            return Repository.Delete(datas, GetCondition(datas[0]));
        }

        public List<T> GetAll()
        {
            return Repository.GetAll();
        }

        public T GetById(int id)
        {
            return Repository.GetById(id);
        }

        public List<T> GetAllWhere(T data)
        {
            return Repository.GetAllWhere(data, GetCondition(data));
        }

        public bool Update(T data)
        {
            return Repository.Update(data);
        }

        private string GetCondition (T data)
        {
            string condition;
            List<string> fieldList = new List<string>();
            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if ((property.PropertyType == typeof(string) && property.GetValue(data) != null) ||
                    (property.PropertyType == typeof(int) && (int)property.GetValue(data) >= 0) ||
                    (property.PropertyType == typeof(float) && (float)property.GetValue(data) >= 0))
                {
                    fieldList.Add($"{property.Name}=@{property.Name}");
                }
            }

            condition = fieldList.Count > 0 ? string.Join(" AND ", fieldList) : string.Empty;
            return condition;
        }
    }
}
