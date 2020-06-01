using Newtonsoft.Json;
using ShoppingCart.Business.Log;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartWebAPI.HttpClients
{
    public abstract class BaseHttpClient<T> where T : class
    {
        public abstract string Controller { get; }

        public static HttpClient client = new HttpClient
        {
            BaseAddress = new Uri($"{ConfigurationManager.AppSettings["Uri"]}")
        };

        public BaseHttpClient()
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    
        public int Add(T data)
        {
            try
            {
                Task<HttpResponseMessage> postTask = client.PostAsJsonAsync<T>($"{Controller}/Add", data);
                postTask.Wait();

                HttpResponseMessage response = postTask.Result;

                if (response.IsSuccessStatusCode)
                {
                    Task<int> readTask = response.Content.ReadAsAsync<int>();
                    readTask.Wait();
                    return readTask.Result;
                }
                
                return -1;    
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex);
                return -1;
            }
        }

        public bool Delete(List<T> data)
        {
            try
            {
                Task<HttpResponseMessage> deleteTask = client.SendAsync(new HttpRequestMessage(HttpMethod.Delete, $"{Controller}/Delete") 
                { 
                    Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json") 
                });

                deleteTask.Wait();

                HttpResponseMessage response = deleteTask.Result;

                return response.IsSuccessStatusCode;
            }
            catch(Exception ex)
            {
                Logger.log.Error(ex);
                return false;
            }
        }

        public List<T> GetAll()
        {
            try
            {
                Task<HttpResponseMessage> response = client.GetAsync($"{Controller}/GetAll");
                response.Wait();

                HttpResponseMessage result = response.Result;

                if (response.Result.IsSuccessStatusCode)
                {
                    Task<List<T>> readTask = result.Content.ReadAsAsync<List<T>>();
                    readTask.Wait();
                    return readTask.Result;
                }

                return new List<T>();
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex);
                return new List<T>();
            }
        }

        public List<T> Find(T data)
        {
            try
            {
                Task<HttpResponseMessage> response = client.PostAsJsonAsync<T>($"{Controller}/Find", data);

                response.Wait();

                HttpResponseMessage result = response.Result;

                if (response.Result.IsSuccessStatusCode)
                {
                    Task<List<T>> readTask = result.Content.ReadAsAsync<List<T>>();
                    readTask.Wait();
                    return readTask.Result;
                }

                return new List<T>();
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex);
                return new List<T>();
            }
        }

        public T GetById(int id)
        {
            try
            {
                Task<HttpResponseMessage> response = client.GetAsync($"{Controller}/GetById/{id}");
                response.Wait();

                HttpResponseMessage result = response.Result;

                if (response.Result.IsSuccessStatusCode)
                {
                    Task<T> readTask = result.Content.ReadAsAsync<T>();
                    readTask.Wait();
                    return readTask.Result;
                }

                return null;
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex);
                return null;
            }
        }

        public bool Update(T data)
        {
            try
            {
                Task<HttpResponseMessage> postTask = client.PutAsJsonAsync<T>($"{Controller}/Update", data);
                postTask.Wait();

                HttpResponseMessage result = postTask.Result;
                return result.IsSuccessStatusCode;
            }
            catch(Exception ex)
            {
                Logger.log.Error(ex);
                return false;
            }
        }
    }
}
