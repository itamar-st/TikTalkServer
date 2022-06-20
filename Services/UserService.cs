using Domain;

namespace Services
{
    public class UserService : IUsersService
    {
        //hardcoded list to represent the DB
        private static ICollection<User> _users = new List<User>() {
                                                                        new User() {
                                                                            Id = "emma",
                                                                            Name = "emma",
                                                                            Password = "12345678Aa",
                                                                            ProfilePic = "",
                                                                            Contacts = new List<Contact>()
                                                                            {
                                                                                new Contact() {
                                                                                    Id = "itamar",
                                                                                    Name = "itamar",
                                                                                    Last = "1",
                                                                                    Lastdate = "28/05/2022 12:12:26",
                                                                                    Server = "localhost:5051",
                                                                                    ChatWithContact = new List<Message>()
                                                                                    {
                                                                                        new Message() {
                                                                                            Id = 0,
                                                                                            Created = "28/05/2022 12:12:23",
                                                                                            Sent = true,
                                                                                            Content = "hi itamar, how are you?"
                                                                                        },

                                                                                         new Message() {
                                                                                            Id = 1,
                                                                                            Created = "28/05/2022 12:12:26",
                                                                                            Sent = false,
                                                                                            Content = "aaaaaaa"
                                                                                        }
                                                                                    }

                                                                                }

                                                                            }
                                                                        } ,

                                                                        new User()
                                                                        {
                                                                            Id = "gil",
                                                                            Name = "gili", 
                                                                            Password = "12345678Aa",
                                                                            ProfilePic = "",
                                                                            Contacts = new List<Contact>()
                                                                        },

                                                                        new User()
                                                                        {
                                                                            Id = "dude",
                                                                            Name = "dude",
                                                                            Password = "12345678Aa",
                                                                            ProfilePic = "",
                                                                            Contacts = new List<Contact>()
                                                                        },

                                                                        new User()
                                                                        {
                                                                            Id = "itamar",
                                                                            Name = "itamar",
                                                                            Password = "12345678Aa",
                                                                            ProfilePic = "",
                                                                            Contacts = new List<Contact>()
                                                                            {
                                                                                 new Contact() {
                                                                                    Id = "emma",
                                                                                    Name = "emma",
                                                                                    Last = "bbbbbbbbbb",
                                                                                    Lastdate = "28/05/2022 12:12:26",
                                                                                    Server = "localhost:5051",
                                                                                    ChatWithContact = new List<Message>()
                                                                                     {
                                                                                        new Message() {
                                                                                            Id = 0,
                                                                                            Created = "28/05/2022 12:12:23",
                                                                                            Sent = false,
                                                                                            Content = "hi itamar, how are you?"
                                                                                        },

                                                                                         new Message() {
                                                                                            Id = 1,
                                                                                            Created = "28/05/2022 12:12:26",
                                                                                            Sent = true,
                                                                                            Content = "good, how are you?"
                                                                                        }
                                                                                    }

                                                                                }
                                                                            }
                                                                        }
                                                                    };


        // get all users
        // GET: api/<UsersController>
        public IEnumerable<User> Get()
        {
            try
            {
                return _users;
            }
            catch { return null; }
        }


        // get user
        // GET api/<UsersController>/5
        public User Get(string id)
        {
            try
            {
                return _users.FirstOrDefault(x => x.Id == id);
            }
            catch { return null; }
        }


        // add user
        // POST api/<UsersController>
        //public void Post([FromBody] User user)
        public bool Post(User user)
        {
            try
            {
                _users.Add(user);
                return true;
            }
            catch { return false; }
        }


        // edit user
        // PUT api/<UsersController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}


        // delete user
        // DELETE api/<UsersController>/5
        public bool Delete(string id)
        {
            try
            {
                _users.Remove(_users.Where(x => x.Id == id).First());
                return true;
            }
            catch { return false; }
        }
    }
}

