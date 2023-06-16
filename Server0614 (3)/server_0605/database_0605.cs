using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Reflection; 
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
                    string query = "CREATE TABLE IF NOT EXISTS Users (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, StudentID TEXT, Password TEXT)";

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
                    string query = "INSERT INTO Users (Name, StudentID, Password) VALUES (@Name, @StudentID, @Password)";

                    command.CommandText = query;
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@StudentID", studentID);
                    command.Parameters.AddWithValue("@Password", password);

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
                    string query = "SELECT * FROM Users";

                    command.CommandText = query;

                    DataTable dataTable = new DataTable();

                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }

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
                    string query = "DELETE FROM Users";

                    command.CommandText = query;

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
                    string query = "SELECT COUNT(*) FROM Users WHERE StudentID = @StudentID AND Name = @Name AND Password = @Password";

                    command.CommandText = query;
                    command.Parameters.AddWithValue("@StudentID", studentID);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Password", password);

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
                    string query = "SELECT COUNT(*) FROM Users WHERE StudentID = @StudentID AND Password = @Password";

                    command.CommandText = query;
                    command.Parameters.AddWithValue("@StudentID", studentID);
                    command.Parameters.AddWithValue("@Password", password);

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


