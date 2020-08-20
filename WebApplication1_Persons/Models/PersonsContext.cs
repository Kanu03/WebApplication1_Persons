using PersonsModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1_Persons.Models
{
	public class PersonsContext : DbContext
	{
		public PersonsContext(DbContextOptions<PersonsContext> options)
		   : base(options)
		{ }

		public DbSet<Person> Persons { get; set; }

	}
}