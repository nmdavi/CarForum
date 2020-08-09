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
    public class ForumController : ApiController
    {
        private readonly IGenericRepository _repository;

        public ForumController(IGenericRepository repository)
        {
            _repository = repository;
        }

        [Authorize(Roles = "Member")]
        public HttpResponseMessage Get()
        {
            try
            {
                var entity = _repository.GetAll<Forum>();
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message);
            }
        }

        [Authorize(Roles = "Member")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var entity = _repository.Get<Forum>(id);
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        public HttpResponseMessage Post(Forum entity)
        {
            try
            {
                ForumValidator validations = new ForumValidator();
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

        [Authorize(Roles = "Admin")]
        public HttpResponseMessage Put(Forum entity)
        {
            try
            {
                _repository.Update<Forum>(entity);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                _repository.Delete<Forum>(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message);
            }
        }
    }
}