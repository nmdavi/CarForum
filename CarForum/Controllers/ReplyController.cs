using CarForum.Models;
using CarForum.Models.Repository;
using CarForum.Models.Validator;
using FluentValidation.Results;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarForum.Controllers
{
    [Authorize(Roles = "Member")]
    public class ReplyController : ApiController
    {
        private readonly IGenericRepository _repository;

        public ReplyController(IGenericRepository repository)
        {
            _repository = repository;
        }

        public HttpResponseMessage Get()
        {
            try
            {
                var entity = _repository.GetAll<Reply>();
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message);
            }
        }

        public HttpResponseMessage Get(int id)
        {
            try
            {
                var entity = _repository.Get<Reply>(id);
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message);
            }
        }

        public HttpResponseMessage Post(Reply entity)
        {
            try
            {
                ReplyValidator validations = new ReplyValidator();
                ValidationResult failures = validations.Validate(entity);

                if (failures.IsValid)
                {
                    var created = _repository.Create(entity);

                    return Request.CreateResponse(HttpStatusCode.Created, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, failures.Errors[0].ToString());
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message);
            }
        }

        public HttpResponseMessage Put(Reply entity)
        {
            try
            {
                _repository.Update<Reply>(entity);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message);
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                _repository.Delete<Reply>(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message);
            }
        }
    }
}