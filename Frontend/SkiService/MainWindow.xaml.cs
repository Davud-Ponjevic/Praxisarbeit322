using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SkiService
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private List<ServiceAuftrag> serviceAuftraege;
        private bool isLoggedIn = false;
        private string currentUser = "";

        /// <summary>
        /// Dictionary zum Speichern von Benutzername und Passwort
        /// </summary>
        private Dictionary<string, string> adminCredentials = new Dictionary<string, string>
        {
            {"Admin1", "Passwort1"},
            {"Admin2", "Passwort2"},
            {"Admin10", "Passwort10"}
        };

        public MainWindow()
        {
            InitializeComponent();
            InitializeData();
            DataContext = this;
        }

        /// <summary>
        /// Initialisiert Beispieldaten für Serviceaufträge
        /// </summary>
        private void InitializeData()
        {
            serviceAuftraege = new List<ServiceAuftrag>
            {
                new ServiceAuftrag { KundenName = "Max Mustermann", Dienstleistung = Dienstleistung.KleinerService, Prioritaet = Prioritaet.Hoch, Status = Status.Offen },
                new ServiceAuftrag { KundenName = "Erika Musterfrau", Dienstleistung = Dienstleistung.RennskiService, Prioritaet = Prioritaet.Niedrig, Status = Status.InArbeit },
                new ServiceAuftrag { KundenName = "Max Mustermann", Dienstleistung = Dienstleistung.KleinerService, Prioritaet = Prioritaet.Hoch, Status = Status.Offen },
                new ServiceAuftrag { KundenName = "Erika Musterfrau", Dienstleistung = Dienstleistung.RennskiService, Prioritaet = Prioritaet.Niedrig, Status = Status.InArbeit },
                new ServiceAuftrag { KundenName = "Max Mustermann", Dienstleistung = Dienstleistung.KleinerService, Prioritaet = Prioritaet.Hoch, Status = Status.Offen },
                new ServiceAuftrag { KundenName = "Erika Musterfrau", Dienstleistung = Dienstleistung.RennskiService, Prioritaet = Prioritaet.Niedrig, Status = Status.InArbeit },
                new ServiceAuftrag { KundenName = "Max Mustermann", Dienstleistung = Dienstleistung.KleinerService, Prioritaet = Prioritaet.Hoch, Status = Status.Offen },
                new ServiceAuftrag { KundenName = "Erika Musterfrau", Dienstleistung = Dienstleistung.RennskiService, Prioritaet = Prioritaet.Niedrig, Status = Status.InArbeit },               
                new ServiceAuftrag { KundenName = "Erika Musterfrau", Dienstleistung = Dienstleistung.RennskiService, Prioritaet = Prioritaet.Niedrig, Status = Status.InArbeit },
                new ServiceAuftrag { KundenName = "Max Mustermann", Dienstleistung = Dienstleistung.KleinerService, Prioritaet = Prioritaet.Hoch, Status = Status.Offen },
                new ServiceAuftrag { KundenName = "Erika Musterfrau", Dienstleistung = Dienstleistung.RennskiService, Prioritaet = Prioritaet.Niedrig, Status = Status.InArbeit },             
                new ServiceAuftrag { KundenName = "Erika Musterfrau", Dienstleistung = Dienstleistung.RennskiService, Prioritaet = Prioritaet.Niedrig, Status = Status.InArbeit },
                new ServiceAuftrag { KundenName = "Max Mustermann", Dienstleistung = Dienstleistung.KleinerService, Prioritaet = Prioritaet.Hoch, Status = Status.Offen },
                new ServiceAuftrag { KundenName = "Erika Musterfrau", Dienstleistung = Dienstleistung.RennskiService, Prioritaet = Prioritaet.Niedrig, Status = Status.InArbeit },
            };
        }

        /// <summary>
        /// Aktualisiert die ListView mit den Serviceaufträgen
        /// </summary>
        private void UpdateListView()
        {
            serviceAuftraege = serviceAuftraege.OrderByDescending(auftrag => auftrag.Prioritaet).ToList();
            serviceListView.ItemsSource = serviceAuftraege;
        }

        /// <summary>
        /// Filtert die Liste nach dem angegebenen Text
        /// </summary>
        private void FilterList(string filterText)
        {
            var filteredList = serviceAuftraege.Where(auftrag => auftrag.KundenName.Contains(filterText)).ToList();
            serviceListView.ItemsSource = filteredList;
        }

        /// <summary>
        /// Event-Handler für den Login-Button
        /// </summary>
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isLoggedIn)
            {
                string enteredUsername = usernameTextBox.Text;
                string enteredPassword = passwordBox.Password;

                if (adminCredentials.ContainsKey(enteredUsername) && adminCredentials[enteredUsername] == enteredPassword)
                {
                    isLoggedIn = true;
                    currentUser = enteredUsername;
                    IsLoggedIn = true; 

                    adminFunctionsGrid.Visibility = Visibility.Visible;

                    UpdateListView(); 
                }
                else
                {
                    MessageBox.Show("Ungültige Anmeldeinformationen.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Sie sind bereits angemeldet.", "Hinweis", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// Event-Handler für den Suchen-Button
        /// </summary>
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (isLoggedIn)
            {
                FilterList(searchTextBox.Text);
            }
            else
            {
                MessageBox.Show("Sie müssen sich zuerst einloggen.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Event-Handler für den Löschen-Button
        /// </summary>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (isLoggedIn)
            {
                var selectedAuftrag = serviceListView.SelectedItem as ServiceAuftrag;
                if (selectedAuftrag != null)
                {
                    serviceAuftraege.Remove(selectedAuftrag);
                    UpdateListView();
                }
                else
                {
                    MessageBox.Show("Wählen Sie einen Auftrag zum Löschen aus.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Sie müssen sich zuerst einloggen.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Eigenschaft für die Bindung der Schaltfläche
        /// </summary>
        private bool isLoggedInProperty;

        /// <summary>
        /// Gibt an, ob der Benutzer angemeldet ist oder nicht
        /// </summary>
        public bool IsLoggedIn
        {
            get { return isLoggedInProperty; }
            set
            {
                isLoggedInProperty = value;
                OnPropertyChanged(nameof(IsLoggedIn));
            }
        }

        /// <summary>
        /// Event-Handler für das PropertyChanged-Event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Methode zum Auslösen des PropertyChanged-Events
        /// </summary>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Event-Handler für den "Änderungen übernehmen"-Button
        /// </summary>
        private void ApplyChangesButton_Click(object sender, RoutedEventArgs e)
        {
            if (isLoggedIn)
            {

                MessageBox.Show("Änderungen übernommen.", "Erfolg", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateListView();
            }
            else
            {
                MessageBox.Show("Sie müssen sich zuerst einloggen.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Event-Handler für den "Änderungen speichern"-Button
        /// </summary>
        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            if (isLoggedIn)
            {
                MessageBox.Show("Änderungen gespeichert.", "Erfolg", MessageBoxButton.OK, MessageBoxImage.Information);
                UpdateListView();
            }
            else
            {
                MessageBox.Show("Sie müssen sich zuerst einloggen.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }


    public class ServiceAuftrag
    {
        public string KundenName { get; set; }
        public Dienstleistung Dienstleistung { get; set; }
        public Prioritaet Prioritaet { get; set; }
        public Status Status { get; set; }
    }

    public enum Dienstleistung
    {
        KleinerService,
        GrosserService,
        RennskiService,
        BindungMontieren,
        Heisswachsen
    }

    public enum Prioritaet
    {
        Niedrig,
        Mittel,
        Hoch
    }

    public enum Status
    {
        Offen,
        InArbeit,
        Abgeschlossen
    }
}
