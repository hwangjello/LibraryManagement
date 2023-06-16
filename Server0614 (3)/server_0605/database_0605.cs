using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Reflection; //Assembly
using System.IO;

public class DatabaseConnector
{
    private string connectionString;

    public DatabaseConnector(string dbFilePath)
    {
        connectionString = $"Data Source=C:\\Users\\jmhwa\\LibraryManagement\\ScienceLibrary\\DB\\info.db;Version=3;";
    }

    public async Task CreateDatabase()
    {
        try
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SQLiteCommand(connection))
                {
                    // SQL 쿼리 문자열 생성
                    string query = "CREATE TABLE IF NOT EXISTS Users (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, StudentID TEXT, Password TEXT)";

                    // SQL 쿼리 실행
                    command.CommandText = query;
                    await command.ExecuteNonQueryAsync();
                }
            }

            Console.WriteLine("데이터베이스가 생성되었습니다.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("오류 발생: " + ex.Message);
        }
    }

    public async Task InsertUser(string name, string studentID, string password)
    {
        try
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SQLiteCommand(connection))
                {
                    // SQL 쿼리 문자열 생성
                    string query = "INSERT INTO Users (Name, StudentID, Password) VALUES (@Name, @StudentID, @Password)";

                    // SQL 쿼리에 매개변수 바인딩
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@StudentID", studentID);
                    command.Parameters.AddWithValue("@Password", password);

                    // SQL 쿼리 실행
                    await command.ExecuteNonQueryAsync();
                }
            }

            Console.WriteLine("사용자 정보가 데이터베이스에 삽입되었습니다.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("오류 발생: " + ex.Message);
        }
    }
    public async Task PrintUsers()
    {
        try
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SQLiteCommand(connection))
                {
                    // SQL 쿼리 문자열 생성
                    string query = "SELECT * FROM Users";

                    // SQL 쿼리에 매개변수 바인딩
                    command.CommandText = query;

                    // 데이터를 담을 DataTable 생성
                    DataTable dataTable = new DataTable();

                    // 데이터 가져오기
                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }

                    // 테이블 출력
                    Console.WriteLine("Users 테이블 내용:");
                    foreach (DataRow row in dataTable.Rows)
                    {
                        Console.WriteLine($"Id: {row["Id"]}, Name: {row["Name"]}, StudentID: {row["StudentID"]}, Password: {row["Password"]}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("오류 발생: " + ex.Message);
        }
    }

    public async Task ClearUsers()
    {
        try
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SQLiteCommand(connection))
                {
                    // SQL 쿼리 문자열 생성
                    string query = "DELETE FROM Users";

                    // SQL 쿼리에 매개변수 바인딩
                    command.CommandText = query;

                    // SQL 쿼리 실행
                    await command.ExecuteNonQueryAsync();

                    Console.WriteLine("Users 테이블이 비워졌습니다.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("오류 발생: " + ex.Message);
        }
    }

    public async Task<bool> CompareUser(string studentID, string name, string password)
    {
        try
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SQLiteCommand(connection))
                {
                    // SQL 쿼리 문자열 생성
                    string query = "SELECT COUNT(*) FROM Users WHERE StudentID = @StudentID AND Name = @Name AND Password = @Password";

                    // SQL 쿼리에 매개변수 바인딩
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@StudentID", studentID);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Password", password);

                    // SQL 쿼리 실행하여 결과 조회
                    int count = Convert.ToInt32(await command.ExecuteScalarAsync());

                    return count > 0;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("오류 발생: " + ex.Message);
            return false;
        }
    }
    public async Task<bool> LoginSucces(string studentID, string password)
    {
        try
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SQLiteCommand(connection))
                {
                    // SQL 쿼리 문자열 생성
                    string query = "SELECT COUNT(*) FROM Users WHERE StudentID = @StudentID AND Password = @Password";

                    // SQL 쿼리에 매개변수 바인딩
                    command.CommandText = query;
                    command.Parameters.AddWithValue("@StudentID", studentID);
                    command.Parameters.AddWithValue("@Password", password);

                    // SQL 쿼리 실행하여 결과 조회
                    int count = Convert.ToInt32(await command.ExecuteScalarAsync());

                    return count > 0;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("오류 발생: " + ex.Message);
            return false;
        }
    }
}


