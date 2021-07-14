using ShoppingCart.Business.Entities;
using ShoppingCart.Business.Log;
using ShoppingCart.Business.Manager;
using ShoppingCart.Business.Manager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ShoppingCartWebAPI.Controllers.API
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [Route("api/{controller}")]
    public abstract class BaseController<T> : ApiController where T : class
    {
        public abstract IManager<T> Manager { get; }

        [HttpPost]
        [Route("Add")]
        public IHttpActionResult Add([FromBody]T data)
        {
            try
            {
                int id;
                return (id = Manager.Add(data)) > 0 ? (IHttpActionResult)Ok(id) : NotFound();
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex);
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                                       "Error"));
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(List<T> data)
        {
            try
            {
                return Manager.Delete(data) ? (IHttpActionResult)Ok() : NotFound();
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex);
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                                       "Error"));
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public IHttpActionResult GetAll()
        {
            try
            {
                List<T> result = Manager.GetAll();
                return result.Count > 0 ? (IHttpActionResult)Ok(result) : NotFound();
            }
            catch(Exception ex)
            {
                Logger.log.Error(ex);
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                                       "Error"));
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetById(int id)
        {
            try
            { 
                T result = Manager.GetById(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex);
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                                       "Error"));
            }
        }

        [HttpPost]
        [Route("Find")]
        public IHttpActionResult Find(T data)
        {
            try
            {
                List<T> result = Manager.GetAllWhere(data);
                return result.Count > 0 ? (IHttpActionResult)Ok(result) : NotFound();
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex);
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                                      "Error"));
            }
        }

        [HttpPut]
        [Route("Update")]
        public IHttpActionResult Update(T data)
        {
            try
            {
                return Manager.Update(data) ? (IHttpActionResult)Ok() : ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                                                                                        "Can't update."));
            }
            catch(Exception ex)
            {
                Logger.log.Error(ex);
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError,
                                        "Error"));
            }
        }
    }
}
