using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using WebApplication1.DataAccess.Interfaces;
using WebApplication1.DataAccess.Models;
using System.Text.Json.Serialization;

namespace WebApplication1.DataAccess.Repository
{
    public class StudentRepository : IStudentRepository
    {
        ApplicationDBContext appDBContext;

        public StudentRepository(ApplicationDBContext context)
        {
            appDBContext = context;
        }

        public async Task<Student> CreateStudent(Student request)
        {
            try
            {
                var newStudent = new Student
                {

                    StuRegId = request.StuRegId,
                    StuName = request.StuName,
                    StuEmail = request.StuEmail,
                    StuMobNum = request.StuMobNum,
                    DOB = request.DOB,
                    StuAddress = request.StuAddress,
                    Password = request.Password,
                };
                var obj = appDBContext.Students.Add(newStudent);
                await appDBContext.SaveChangesAsync();
                return obj.Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> DeleteStudent(int StudentId)
        {
            try
            {
                var obj = await appDBContext.Students.FirstOrDefaultAsync(e => e.StuRegId == StudentId);
                if (obj != null)
                {
                    appDBContext.Students.Remove(obj);
                    await appDBContext.SaveChangesAsync();
                    return obj.StuRegId;
                }
                return 0;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public IEnumerable<Student> GetAllStudents()
        {
            try
            {
                return appDBContext.Students.Where(student => !student.userRole).ToList();

            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<Student> GetStudentById(int id)
        {
            try
            {
                return await appDBContext.Students.FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static async Task GenerateAccessToken()
        {
            string tokenEndpoint = "https://identity.nexar.com/connect/token";
            string clientId = "YOUR_CLIENT_ID";
            string clientSecret = "YOUR_CLIENT_SECRET";

            var httpClient = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Post, tokenEndpoint);
            request.Headers.Authorization = CreateBasicAuthenticationHeader(clientId, clientSecret);
            request.Content = new FormUrlEncodedContent(
                new Dictionary<string, string>
                {
                    { "grant_type", "client_credentials" },
                    { "scope", "supply.domain" }
                });

            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            var respObj = JsonSerializer.Deserialize<TokenResponse>(content);
            string accessToken = respObj.AccessToken;

            Console.WriteLine($"Access token: {accessToken}");
        }

        private static AuthenticationHeaderValue CreateBasicAuthenticationHeader(string clientId, string clientSecret)
        {
            string creds = $"{clientId}:{clientSecret}";
            string encodedCreds = Convert.ToBase64String(Encoding.UTF8.GetBytes(creds));
            return new AuthenticationHeaderValue("Basic", encodedCreds);
        }
        public async Task<Student> UpdateStudent(Student student)
        {
            try
            {
                var result = await appDBContext.Students.FirstOrDefaultAsync(e => e.StuRegId == student.StuRegId);

                if (result != null)
                {

                    //result.Name = student.StuRegId;
                    //result.Address = student.Address;
                    //result.Email = student.Email;
                    //result.Mobile = student.Mobile;
                    //result.Password = student.Password;


                    result.StuRegId = student.StuRegId;
                    result.StuName = student.StuName;
                    result.StuEmail = student.StuEmail;
                    result.StuMobNum = student.StuMobNum;
                    result.DOB = student.DOB;
                    result.StuAddress = student.StuAddress;
                    result.Password = student.Password;


                    await appDBContext.SaveChangesAsync();
                    return result;

                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    internal class TokenResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonPropertyName("scope")]
        public string Scope { get; set; }
    }
}
