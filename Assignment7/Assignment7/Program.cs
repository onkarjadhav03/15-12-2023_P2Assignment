using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    internal class Program
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataAdapter sda;
        public static DataSet ds;
        public static string constr = " server=DESKTOP-VDRMSHO;database=LibraryDb;trusted_connection=true;";

        public static void RetriveBook()
        {
            try
            {
                con = new SqlConnection(constr);
                cmd = new SqlCommand("select * from Books", con);
                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                con.Open();
                sda.Fill(ds, "Books");
                Console.WriteLine("enter id to be searched");
                int bid = int.Parse(Console.ReadLine());
                DataRow dr = null;
                foreach (DataRow row in ds.Tables["Books"].Rows)
                {
                    if ((int)row["Bookid"] == bid)
                    {
                        dr = row;
                        Console.WriteLine("Record found details as follows");
                        Console.WriteLine("cid:\t" + row["Bookid"]);
                        Console.WriteLine("Title:\t" + row["Title"]);
                        Console.WriteLine("Author:\t" + row["Author"]);
                        Console.WriteLine("Genre:\t" + row["Genre"]);
                        Console.WriteLine("Quantity:  " + row["Quantity"]);
                     
                    }
                }
                if (dr == null)
                {
                    Console.WriteLine("no such id");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("error" + ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }

        public static void DisplayBooks()
        {
            try
            {
                con = new SqlConnection(constr);
                cmd = new SqlCommand("select * from Books", con);
                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                con.Open();
                sda.Fill(ds);
                con.Close();
                Console.WriteLine("Book Id\t Book Title\t Author\t\t\t Genre\t\t\tQuantity");
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Console.Write(row[0] + "\t ");
                    Console.Write(row[1] + "\t\t");
                    Console.Write(row[2] + "\t\t");
                    Console.Write(row[3] + "\t\t");
                    Console.Write(row[4] + "\t\t");
                    Console.WriteLine("\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }

        public static void AddBook()
        {
            try
            {
                con = new SqlConnection(constr);
                cmd = new SqlCommand("select * from Books", con);
                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                con.Open();
                sda.Fill(ds, "Books");
                DataTable dt = ds.Tables["Books"];
                DataRow dr = dt.NewRow();
                Console.WriteLine("Enter Books ID");
                dr["Bookid"] = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter  Title");
                dr["Title"] = Console.ReadLine();
                Console.WriteLine("Enter  Author");
                dr["Author"] = Console.ReadLine();
                Console.WriteLine("Enter  Genre");
                dr["Genre"] = Console.ReadLine();
                Console.WriteLine("Enter Books Quantity");
                dr["Quantity"] = int.Parse(Console.ReadLine());

                dt.Rows.Add(dr);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                sda.Update(ds, "Books");
                Console.WriteLine("Books record inserted");
                con.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("error" + ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }

        public static void UpdateBook()
        {
            try
            {
                con = new SqlConnection(constr);
                cmd = new SqlCommand("select * from Books", con);
                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                con.Open();
                sda.Fill(ds, "Books");
                Console.WriteLine("enter id to be updated");
                int bid = int.Parse(Console.ReadLine());
                DataRow dr = null;
                foreach (DataRow row in ds.Tables["Books"].Rows)
                {
                    if ((int)row["BookId"] == bid)
                    {
                        dr = row;
                        break;
                    }
                }
                if (dr == null)
                {
                    Console.WriteLine("no such id");
                }
                else
                {
                    Console.WriteLine("enter Book Title");
                    dr["Title"] = Console.ReadLine();
                    Console.WriteLine("enter Book Author");
                    dr["Author"] = Console.ReadLine();
                    Console.WriteLine("enter Book Genre");
                    dr["Genre"] = Console.ReadLine();
                    Console.WriteLine("enter Book Quantity");
                    dr["Quantity"] = int.Parse(Console.ReadLine());


                    SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                    sda.Update(ds, "Books");
                    Console.WriteLine("record updated");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error" + ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("1.Retrive Books\n2.Display Books\n3.Add New Book\n4.Update Book");
            Console.WriteLine("Enter ypur choice");
            int ch=int.Parse(Console.ReadLine());
            switch(ch)
            {
                case 1:
                        RetriveBook();
                    break;

                case 2:
                        DisplayBooks();
                    break;

                case 3:
                        AddBook();
                    break;
                case 4:
                        UpdateBook();
                    break;
                default: Console.WriteLine("invalid input");
                    break;
            }
        }
    }
}
