using System;
class mainClass
{
    class Library
    {
        private string Name;
        private string Address;
        private List<Book> Books;
        private List<MediaItem> MediaItems;

        public Library()
        {
            Name = string.Empty;
            Address = string.Empty;
            Books = new List<Book>();
            MediaItems = new List<MediaItem>();
        }
        public void setName(string name)
        {
            Name = name;
        }
        public void setAddress(string address)
        {
            Address = address;
        }

        public void addBook(Book book) { 
            Books.Add(book);
        }
        public void removeBook(Book book) {
            Books.Remove(book);
        }
        public void addMediaItem(MediaItem mediaItem) { 
            MediaItems.Add(mediaItem);
        }
        public void removeMediaItem(MediaItem mediaItem) {
            MediaItems.Remove(mediaItem);
        }

        public Book searchBook(string name)
        {
            foreach (var book in Books)
            {
                if (book.getTitle().Equals(name)){
                    return book;
                }
            }
            return null;
        }

        public MediaItem searchMedia(string name)
        {
            foreach (var media in MediaItems)
            {
                if (media.getTitle().Equals(name))
                {
                    return media;
                }
            }
            return null;
        }
        public void printCatalog() {
            Console.WriteLine($"Welcome to {Name}, {Address}");
            Console.WriteLine("Books");
            Console.WriteLine("Title \t Author \t ISBN \t publicationYear");
            foreach(var book in Books)
            {
                Console.WriteLine($"{book.getTitle()} \t {book.getAuthor()} \t {book.getISBN()} \t {book.getPublicationYear()}");
            }

            Console.WriteLine("\nMediaItems");
            Console.WriteLine("Title \t MediaType \t duration");
            foreach (var media in MediaItems)
            {
                Console.WriteLine($"{media.getTitle()} \t {media.getMediaType()} \t {media.getDuration()}");
            }
        }



    }

    class Book
    {
        private string Title;
        private string Author;
        private string ISBN;
        private int publicationYear;

        public Book()
        {
            Title = string.Empty;
            Author = string.Empty;
            ISBN = string.Empty;
            publicationYear = 0;
        }

        public void setTitle(string title) {
            Title = title;
        }
        public void setAuthor(string author) {
            Author = author;
        } 
        public void setISBN(string isbn) {
            ISBN = isbn;
        }   
        public void setPublicationYear(int year) {
            publicationYear = year;
        }

        public string getTitle() { return Title; }
        public string getAuthor() { return Author; }

        public string getISBN() { return ISBN; }
        public int getPublicationYear() { return publicationYear; }

    }
    class MediaItem
    {
        private string Title;
        private string MediaType;
        private int Duration;
        public MediaItem()
        {
            Title = string.Empty;
            MediaType = string.Empty;
            Duration = 0;
        }

        public void setTitle(string title)
        {
            Title = title;
        }
        public void setMediaType(string mediaType)
        {
            MediaType = mediaType;
        }
        public void setDuration(int duration)
        {
            Duration = duration;
        }
        public string getTitle() { return Title; }
        public string getMediaType() { return MediaType; }
        public int getDuration() { return  Duration; }
    }

    public string inputAccepeter(string param)
    {
        string input;
        do
        {
            Console.WriteLine($"enter the input {param}, input can not be empty");
            input = Console.ReadLine();
        } while (string.IsNullOrEmpty(input));
        return input;
    }
    public int forInt(string str)
    {
        int value;
        if (string.IsNullOrEmpty(str) || !int.TryParse(str, out value)) { 
            return 1000;
        }

        return value;

    }

    public static void Main(string[] args)
    {
        mainClass mainClass = new mainClass();
        Library library = new Library();
        bool flag = true;
        do
        {
            Console.WriteLine("enter your choice");
            Console.WriteLine(" 1. add the name of library  \n 2. add the address of the library \n 3. add a book \n 4. add a media item \n 5. remove a book \n 6. remove mediaItem \n 7. print catalog \n other. exit");
            int choice = Convert.ToInt32 (Console.ReadLine());
            if (choice< 8 && choice > 0)
            {
                if (choice == 1){
                   library.setName( mainClass.inputAccepeter("name of library"));
                }else if(choice == 2)
                {
                    library.setAddress(mainClass.inputAccepeter("address of library"));
                }else if(choice == 3)
                {
                    Book book = new Book();
                    book.setTitle(mainClass.inputAccepeter("title of book"));
                    book.setAuthor(mainClass.inputAccepeter("author of book"));
                    book.setISBN(mainClass.inputAccepeter("ISBN of book"));
                    book.setPublicationYear(mainClass.forInt(mainClass.inputAccepeter("publication of book")));
                    library.addBook(book);
                }else if(choice == 4)
                {
                    MediaItem item = new MediaItem();
                    item.setTitle(mainClass.inputAccepeter("title of media item"));
                    item.setMediaType(mainClass.inputAccepeter("type of media item"));
                    item.setDuration(mainClass.forInt(mainClass.inputAccepeter("duration of media item")));
                    library.addMediaItem(item);
                }else if(choice == 5)
                {
                    Book book = library.searchBook(mainClass.inputAccepeter("title of the book"));
                    if (book != null)
                    {
                        library.removeBook(book);
                        Console.WriteLine(book.getTitle() +" was removed");
                    }
                    else
                    {
                        Console.WriteLine("not found");
                    }
                }else if(choice == 6)
                {
                    MediaItem mediaItem = library.searchMedia(mainClass.inputAccepeter("title of the media item"));
                    if (mediaItem != null)
                    {
                        library.removeMediaItem(mediaItem);
                        Console.WriteLine(mediaItem.getTitle() + " was removed");
                    }
                    else
                    {
                        Console.WriteLine("not found");
                    }
                }else if(choice == 7)
                {
                    library.printCatalog();
                    
                }
                else
                {
                    flag = false;
                }

            }
            else
            {
                flag = false;
            }

        } while (flag);
    }
}
