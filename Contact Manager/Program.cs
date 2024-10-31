namespace Contact_Manager
{
    internal class Program
    {
            static void Main()
            {
                List<Dictionary<string, string>> contacts = new List<Dictionary<string, string>>();
                bool running = true;

                while (running)
                {
                    Console.Clear();
                    Console.WriteLine("Contact Manager");
                    Console.WriteLine("1. Add Contact");
                    Console.WriteLine("2. View Contacts");
                    Console.WriteLine("3. Edit Contact");
                    Console.WriteLine("4. Delete Contact");
                    Console.WriteLine("5. Search Contacts");
                    Console.WriteLine("6. Exit");
                    Console.Write("Select an option: ");
                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            AddContact(contacts);
                            break;
                        case "2":
                            ViewContacts(contacts);
                            break;
                        case "3":
                            EditContact(contacts);
                            break;
                        case "4":
                            DeleteContact(contacts);
                            break;
                        case "5":
                            SearchContacts(contacts);
                            break;
                        case "6":
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please select again.");
                            break;
                    }

                    if (running)
                    {
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                    }
                }
            }

            static void AddContact(List<Dictionary<string, string>> contacts)
            {
                var contact = new Dictionary<string, string>();

                Console.Write("Enter name: ");
                contact["Name"] = Console.ReadLine();

                Console.Write("Enter phone number: ");
                contact["Phone"] = Console.ReadLine();

                Console.Write("Enter email: ");
                contact["Email"] = Console.ReadLine();

                contacts.Add(contact);
                Console.WriteLine("Contact added successfully!");
            }

            static void ViewContacts(List<Dictionary<string, string>> contacts)
            {
                Console.WriteLine("Contacts:");
                foreach (var contact in contacts)
                {
                    Console.WriteLine($"Name: {contact["Name"]}, Phone: {contact["Phone"]}, Email: {contact["Email"]}");
                }
            }

            static void EditContact(List<Dictionary<string, string>> contacts)
            {
                Console.Write("Enter the name of the contact to edit: ");
                string name = Console.ReadLine();

                var contact = contacts.FirstOrDefault(c => c["Name"].Equals(name, StringComparison.OrdinalIgnoreCase));

                if (contact != null)
                {
                    Console.Write("Enter new phone number: ");
                    contact["Phone"] = Console.ReadLine();

                    Console.Write("Enter new email: ");
                    contact["Email"] = Console.ReadLine();

                    Console.WriteLine("Contact updated successfully!");
                }
                else
                {
                    Console.WriteLine("Contact not found.");
                }
            }

            static void DeleteContact(List<Dictionary<string, string>> contacts)
            {
                Console.Write("Enter the name of the contact to delete: ");
                string name = Console.ReadLine();

                var contactToRemove = contacts.FirstOrDefault(c => c["Name"].Equals(name, StringComparison.OrdinalIgnoreCase));

                if (contactToRemove != null)
                {
                    contacts.Remove(contactToRemove);
                    Console.WriteLine("Contact deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Contact not found.");
                }
            }

            static void SearchContacts(List<Dictionary<string, string>> contacts)
            {
                Console.Write("Enter name or phone number to search: ");
                string searchTerm = Console.ReadLine();

                var foundContacts = contacts.Where(c => c["Name"].Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                                                        c["Phone"].Contains(searchTerm)).ToList();

                if (foundContacts.Any())
                {
                    Console.WriteLine("Search Results:");
                    foreach (var contact in foundContacts)
                    {
                        Console.WriteLine($"Name: {contact["Name"]}, Phone: {contact["Phone"]}, Email: {contact["Email"]}");
                    }
                }
                else
                {
                    Console.WriteLine("No contacts found.");
                }
            }
        }

    }

