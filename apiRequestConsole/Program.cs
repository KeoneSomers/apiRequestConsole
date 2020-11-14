using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace apiRequestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var APIclient = new HttpClient();
            APIclient.BaseAddress = new Uri("https://localhost:6001/");

            //HTTP GET
            var responseTask = APIclient.GetAsync("api/StudentController/getAll");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsAsync<StudentModel[]>();
                readTask.Wait();

                var students = readTask.Result;

                foreach (var student in students)
                {
                    Console.WriteLine(student.Name);
                }
            }
            Console.ReadLine();
        }
    }
}