using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Application.Models;

namespace Application.Controllers
{
    public class TasksController : ApiController
    {
        // Data Store (not best practise)
        static readonly TaskRepository repository = new TaskRepository();

        /* Get + /api/tasks */
        public IEnumerable<Task> GetAllTasks() {
            // Return all items
            return repository.GetAll();
        }

        /* Get + /api/tasks/(id) */
        public Task GetTask(int id) {
            Task task = repository.Get(id);
            if (task == null) {
                // Proper HTTP response: Throw 404 if not found. 
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return task;
        }

        /* Post + /api/tasks/(id) */
        public HttpResponseMessage PostTask(Task task) {
            task = repository.Add(task);

            // Create proper 201 (created) response + task
            var response = Request.CreateResponse<Task>(HttpStatusCode.Created, task);

            // Send URL for new task back using Location header
            string uri = Url.Link("DefaultApi", new { id = task.Id });
            response.Headers.Location = new Uri(uri);

            return response;
        }

        /* Put + /api/tasks/(id) */
        public void PutTask(int id, Task task) {
            task.Id = id;
            bool task_found = repository.Update(task);
            if (!task_found) {
                // Throw 404 if not found
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        /* Delete + /api/tasks/(id) */
        public void DeleteTask(int id) {
            Task task = repository.Get(id);
            if (task == null) {
                // Throw 404 if not found
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repository.Remove(id);
        }
    }
}
