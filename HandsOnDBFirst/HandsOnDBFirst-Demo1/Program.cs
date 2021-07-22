using System;
using HandsOnDBFirst_Demo1.Models;
using System.Collections.Generic;
using System.Linq;
using HandsOnDBFirst_Demo1.ViewModels;
namespace HandsOnDBFirst_Demo1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            using (TrainingContext training = new TrainingContext())
            {
                //add new row to Book_Master
                //BookMaster book = new BookMaster()
                //{
                //    BookCode= 10000010,
                //   BookName ="C# 8.0",
                //   PubYear=2020,
                //   Author="Microsoft",
                //   BookCategory="Comp Sc"
                //};
                //training.BookMasters.Add(book);
                //training.SaveChanges();

                //Add multiple rows
                //List<BookMaster> books = new List<BookMaster>()
                //{
                //    new BookMaster()
                //    {
                //        BookCode = 10000011,BookName = "C# 9.0",PubYear = 2020,
                //        Author = "Microsoft",
                //        BookCategory = "Comp Sc"
                //    },
                //     new BookMaster()
                //{
                //    BookCode= 10000012, BookName ="C# 6.0",PubYear=2020,
                //   Author="Microsoft",
                //   BookCategory="Comp Sc"
                //},

                //};
                //training.BookMasters.AddRange(books);
                //training.SaveChanges();
                //fetch single record
                //use find method to search record using primary key
                // BookMaster book1 = training.BookMasters.Find(100000120);
                //use SingleOrDefault method for non primary key and primary
                //BookMaster book1 = training.BookMasters.SingleOrDefault(b => b.BookCode == 100000120);

                //if (book1 != null)
                //    Console.WriteLine($"{book1.BookName} {book1.Author}");
                //else
                //    Console.WriteLine("Invalid Id");
                //Fetch Multiple records or Books
                //List<BookMaster> books1 = training.BookMasters.Where(b => b.Author == "Microsoft").ToList();
                //foreach (var item in books1)
                //    Console.WriteLine($"{item.BookName} {item.Author}");
                //use Group by
                //var books = training.BookMasters.ToList().GroupBy(b => b.Author);
                //foreach (var list in books)
                //{
                //    Console.WriteLine("Books of " + list.Key);
                //    foreach (var item in list)
                //    {
                //        Console.WriteLine($"{item.BookName}");
                //    }
                //}

                //Delete Record

                //BookMaster book1 = training.BookMasters.SingleOrDefault(b => b.BookCode == 10000012);
                //training.BookMasters.Remove(book1);
                //training.SaveChanges();

                //Update Record

                //BookMaster book2 = training.BookMasters.SingleOrDefault(b => b.BookCode == 10000011);
                ////update details
                //book2.PubYear = 2021;
                //book2.Author = "MicroSoft RD";
                //training.BookMasters.Update(book2);
                //training.SaveChanges();

                //Join
                //List<IssueBookToStudent> students = (from s in training.StudentMasters
                //                                     join
                //                                     b in training.BookTransactions
                //                                     on s.StudCode equals b.StudCode
                //                                     select new IssueBookToStudent() {
                //                                         StudCode=s.StudCode,
                //                                         StudName=s.StudName,
                //                                         DeptCode=s.DeptCode,
                //                                         BookCode=b.BookCode,
                //                                         IssueDate=b.IssueDate,
                //                                         ExpReturnDate=b.ExpReturnDate
                //                                     }).ToList();
                List<IssueBookToStudent> students = (from s in training.StudentMasters
                                                     join
                                                     b in training.BookTransactions
                                                     on s.StudCode equals b.StudCode
                                                     join bm in training.BookMasters
                                                     on b.BookCode equals bm.BookCode
                                                     select new IssueBookToStudent()
                                                     {
                                                         StudCode = s.StudCode,
                                                         StudName = s.StudName,
                                                         DeptCode = s.DeptCode,
                                                         BookCode = b.BookCode,
                                                         BookName=bm.BookName,
                                                         IssueDate = b.IssueDate,
                                                         ExpReturnDate = b.ExpReturnDate
                                                     }).ToList();
                foreach (var item in students)
                {
                    Console.WriteLine($"{item.StudCode} {item.StudName} {item.DeptCode} {item.BookCode} " +
                        $"{item.BookName}" +
                        $" {item.IssueDate.ToShortDateString()} {item.ExpReturnDate.ToShortDateString()}");
                }
            }
        }
    }
}
