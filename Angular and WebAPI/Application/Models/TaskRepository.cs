using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models {
    public class TaskRepository {
        private List<Task> tasks = new List<Task>(); // A list to hold tasks

        /* 5 Methods - GetAll and 4 CRUD operations  */

        public IEnumerable<Task> GetAll() {
            return tasks;
        }

        public Task Get(int id) {
            return tasks.FirstOrDefault(task => task.Id == id);
        }

        private int _nextId = 1; // A id counter
        public Task Add(Task task) {
            if (task == null) {
                throw new ArgumentNullException("task");
            }
            task.Id = _nextId++;
            tasks.Add(task);
            return task;
        }

        public void Remove(int id) {
            tasks.RemoveAll(p => p.Id == id);
        }

        public bool Update(Task task) {
            if (task == null) {
                throw new ArgumentNullException("task");
            }

            int index = tasks.FindIndex(p => p.Id == task.Id);
            if (index == -1) {
                return false;
            }

            tasks.RemoveAt(index);
            tasks.Add(task);

            return true;
        }

        /* Constructor - Setup Default Tasks */
        public TaskRepository() {
            Add(new Task() {
                Text = "Item1", Tag = "home",
                TimeSpent = 30, TimeToComplete = 120,
                Completed = false
            });

            Add(new Task() {
                Text = "Item2", Tag = "work",
                TimeSpent = 50, TimeToComplete = 60,
                Completed = true
            });

            Add(new Task() {
                Text = "Item3", Tag = "work",
                TimeSpent = 60, TimeToComplete = 150,
                Completed = false
            });
        }
    }
}