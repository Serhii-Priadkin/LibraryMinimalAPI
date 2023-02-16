using Library.Models;

namespace Library.Data
{
    public static class BookStore
    {
        public static List<Book> bookList = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title="Harry Potter and the Philosopher's Stone",
                Cover="https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcTYGx6w4wW7xmC8h_UdhyzyxhOV4QZofI0lrgZ7JgMkCyqGG5M_",
                Content="Harry Potter, an eleven-year-old orphan, discovers that he is a wizard and is invited to study at Hogwarts. Even as he escapes a dreary life and enters a world of magic, he finds trouble awaiting him.",
                Genre = "Fantasy",
                Author = "J.K. Rowling"
            },
            new Book
            {
                Id = 2,
                Title="Harry Potter and the Chamber of Secrets",
                Cover="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTltzcooPkGcy1fKKqzSuO8U6S9XBpNDR9MuYc9SS_L5AbAn66O",
                Content="A house-elf warns Harry against returning to Hogwarts, but he decides to ignore it. When students and creatures at the school begin to get petrified, Harry finds himself surrounded in mystery.",
                Genre = "Fantasy",
                Author = "J.K. Rowling"
            },
            new Book
            {
                Id = 3,
                Title="Harry Potter and the Prisoner of Azkaban",
                Cover="https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcTQ0zi4n9FsH1q8fyGAXi_fkisY2Krs0_iMzNMYmwIh-DlDxiSR",
                Content="Harry, Ron and Hermoine return to Hogwarts just as they learn about Sirius Black and his plans to kill Harry. However, when Harry runs into him, he learns that the truth is far from reality.",
                Genre = "Fantasy",
                Author = "J.K. Rowling"
            },
            new Book
            {
                Id = 4,
                Title="Harry Potter and the Goblet of Fire",
                Cover="https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcT11kynaj_-X2LgSqeZVCBnO4ZcCPFdvS9x273sUEZNOWb9K8dt",
                Content="When Harry gets chosen as the fourth participant in the inter-school Triwizard Tournament, he is unwittingly pulled into a dark conspiracy that slowly unveils its dangerous agenda.",
                Genre = "Fantasy",
                Author = "J.K. Rowling"
            },
            new Book
            {
                Id = 5,
                Title="The Dark Tower",
                Cover="https://upload.wikimedia.org/wikipedia/en/5/54/Thedarktower7.jpg",
                Content="The Dark Tower is a series of eight novels, one short story, and a children's book written by American author Stephen King.",
                Genre = "Fantasy",
                Author = "Stephen King"
            },
            new Book
            {
                Id = 6,
                Title="It",
                Cover="https://static.wikia.nocookie.net/stephenking/images/8/84/It_by_Stephen_King_-_Book_Cover_V2.jpg/revision/latest/scale-to-width-down/250?cb=20171008091323",
                Content="It is a 1986 horror novel by American author Stephen King. It was his 22nd book and his 17th novel written under his own name. The story follows the experiences of seven children as they are terrorized by an evil entity that exploits the fears of its victims to disguise itself while hunting its prey. ",
                Genre = "Horror",
                Author = "Stephen King"
            },
            new Book
            {
                Id = 7,
                Title="Hercule Poirot",
                Cover="https://www.giantbomb.com/a/uploads/scale_medium/0/378/1726975-poirot.jpg",
                Content="Hercule Poirot is a fictional Belgian detective created by British writer Agatha Christie. Poirot is one of Christie's most famous and long-running characters, appearing in 33 novels, two plays, and more than 50 short stories published between 1920 and 1975.",
                Genre = "Thriller",
                Author = "Agatha Christie"
            },
            new Book
            {
                Id = 8,
                Title="Sherlock Holmes",
                Cover="https://upload.wikimedia.org/wikipedia/commons/c/cd/Sherlock_Holmes_Portrait_Paget.jpg",
                Content="Sherlock Holmes is a fictional detective created by British author Arthur Conan Doyle. Referring to himself as a \"consulting detective\" in the stories, Holmes is known for his proficiency with observation, ...",
                Genre = "Novel",
                Author = "Arthur Conan Doyle"
            },
            new Book
            {
                Id = 9,
                Title="The Lord of the Rings",
                Cover="https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcT11kynaj_-X2LgSqeZVCBnO4ZcCPFdvS9x273sUEZNOWb9K8dt",
                Content="The Lord of the Rings is an epic high-fantasy novel by English author and scholar J. R. R. Tolkien. Set in Middle-earth, the story began as a sequel to Tolkien's 1937 children's book The Hobbit, but eventually developed into a much larger work.",
                Genre = "Fantasy",
                Author = "J. R. R. Tolkien"
            },
            new Book
            {
                Id = 10,
                Title="The Silent Patient",
                Cover="https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRFe_nR8cUhkckk_U_hdIHGQQhMPVp84bvL7eRVV8RL9MF_jEo5",
                Content="The Silent Patient is a 2019 psychological thriller novel written by British–Cypriot author Alex Michaelides. The successful debut novel was published by Celadon Books, a division of Macmillan Publishers, on 5 February 2019. The audiobook version, released on the same date, is read by Louise Brealey and Jack Hawkins.",
                Genre = "Horror",
                Author = "Alex Michaelides"
            }
        };

    }
}
