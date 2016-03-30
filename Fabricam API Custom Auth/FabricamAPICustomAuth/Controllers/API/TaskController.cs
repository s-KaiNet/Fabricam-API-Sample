using System.Collections.Generic;
using System.Web.Http;
using FabricamAPICustomAuth.Core;

namespace FabricamAPICustomAuth.Controllers.API
{
	[RoutePrefix("api/tasks")]
	[Authorize]
	public class TaskController : ApiController
    {
		//GET api/tasks
		[Route]
		public List<string> Get()
		{
			return ToDoService.Get();
		}

		//GET api/tasks/3
		[Route("{index}")]
		public string Get(int index)
		{
			return ToDoService.Get(index);
		}

		//POST api/tasks
		[Route]
		public int Post(ToDoItem item)
		{
			return ToDoService.Add(item.Text);
		}

		// DELETE api/tasks/5
		[Route("{index}")]
		public void Delete(int index)
		{
			ToDoService.Delete(index);
		}
	}
}
