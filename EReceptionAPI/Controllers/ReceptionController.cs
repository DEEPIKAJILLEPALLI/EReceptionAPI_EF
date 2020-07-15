using EReceptionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EReceptionAPI.Controllers
{
        [RoutePrefix("api/reception")]
        public class ReceptionController : ApiController
        {

            [HttpGet]
            [Route("visitors")]
            public List<Visitor> GetAllVisitors()
            {
                List<Visitor> visitorslist = new List<Visitor>();

                using (var ctx = new VisitorDbContext())
                {

                    var query = (from v in ctx.Visitors
                                 select v).ToList();

                    return query;
                }
            }
        [HttpGet]
        [Route("visitors/{id}")]
        public Visitor GetVisitorById(int id)
        {
            using (var ctx = new VisitorDbContext())
            {

                var query = (from v in ctx.Visitors
                             where v.id == id
                             select v).FirstOrDefault();
                return query;
            }
        }
        [HttpPost]
            [Route("newvisitor")]
            public IHttpActionResult PostNewVisitor(Visitor s)
            {

                using (var ctx = new VisitorDbContext())
                {
                    //Visitor vis = ctx.Visitors.;
                    ctx.Visitors.Add(s);
                    ctx.SaveChanges();

                }

                return Ok(true);
            }

            [HttpPut]
            [Route("updatevisitorOutTime")]
            public IHttpActionResult UpdateVisitorOutTime(Visitor s)
            {

                using (var ctx = new VisitorDbContext())
                {
                    Visitor vis = null;
                    vis = ctx.Visitors.Where(v => v.id == s.id).FirstOrDefault();


                    vis.OutTime = s.OutTime;


                    ctx.SaveChanges();

                }

                return Ok(true);
            }

            [HttpPut]
            [Route("updatevisitor")]
            public IHttpActionResult PutVisitor(Visitor s)
            {
                using (var ctx = new VisitorDbContext())
                {


                    var vis = ctx.Visitors.Where(v => v.id == s.id).FirstOrDefault();


                    vis.Name = s.Name;
                    vis.Email = s.Email;
                    vis.Mobile = s.Mobile;
                    vis.Gender = s.Gender;
                    vis.Purpose = s.Purpose;
                    vis.Address = s.Address;
                    vis.ToMeet = s.ToMeet;
                    vis.InTime = s.InTime;
                    vis.OutTime = s.OutTime;



                    ctx.SaveChanges();

                }

                return Ok(true);
            }
            [HttpDelete]
            [Route("deleteVisitor/{id}")]
            public IHttpActionResult Delete(int id)
            {
                if (id <= 0)
                    return BadRequest("Not a valid student id");

                using (var ctx = new VisitorDbContext())
                {


                    Visitor vis = null;
                    vis = ctx.Visitors.Where(v => v.id == id).FirstOrDefault();


                    ctx.Entry(vis).State = System.Data.Entity.EntityState.Deleted;
                    ctx.SaveChanges();
                }

                return Ok(true);
            }

        }
    }
