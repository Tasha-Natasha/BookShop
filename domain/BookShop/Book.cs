﻿using System.Text.RegularExpressions;

namespace BookShop;

public class Book
{
    public int Id { get; }

    public string Isbn { get; }

    public string Author { get; }

    public string Title { get; }

    public Book(int id, string isbn, string author, string title )
    {
        Id = id;
        Title = title;
        Isbn = isbn;
        Author = author;
    }

    internal static bool IsIsbn(string s)
    {
        if (s == null)
        {
            return false;
        }
            

        s = s.Replace("-", "").Replace(" ", "").ToUpper();

        return Regex.IsMatch(s, @"^ISBN\d{10}(\d{3})?$");  
    }
}
