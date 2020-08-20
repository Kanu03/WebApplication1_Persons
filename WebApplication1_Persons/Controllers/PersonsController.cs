using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1_Persons.Models;
using PersonsModels;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1_Persons.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    
    public class PersonsController: ControllerBase
    {
       private readonly PersonsContext _context;

       public PersonsController(PersonsContext context)
       {
          _context = context;
       }

        [Route("GetPersons")]
        [HttpGet]
        public List<Person> GetPersons()
        {
            var s = _context.Persons.ToList();
            return s;
        }

        [Route("AddPerson")]
        [HttpPost]
        public bool AddPerson([FromBody] Person Person)
        {
            _context.Persons.Add(Person);
            try
            {
                _context.SaveChanges();
            }
            catch 
            {
                return false;
            }

            return true;
        }

        [Route("UpdatePerson")]
        [HttpPut]
        public bool UpdatePerson([FromBody] Person Person)
        {
            //_context.Entry(Person).State = EntityState.Modified;
            //_context.SaveChanges();

            using (var trans = _context.Database.BeginTransaction())
            {

                try
                {
                    _context.Entry(Person).State = EntityState.Modified;

                    try
                    {
                        _context.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        return false;
                    }

                    trans.Commit();
                }
                catch (Exception err)
                {
                    trans.Rollback();
                    return false;
                }
            }

            return true;
        }

        [Route("DeletePerson/{id}")]
        [HttpGet]
        public bool DeletePerson(int id)
        {

            var person = _context.Persons.Find(id);
            if (person == null)
            {
                return false;
            }
            _context.Persons.Remove(person);

            try
            {
                _context.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
