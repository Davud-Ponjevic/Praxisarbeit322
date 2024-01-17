using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using System.Threading.Tasks;
using System.Net.Http.Json; 

namespace SkiService
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private List<ServiceAuftrag> serviceAuftraege;
        private bool isLoggedIn = false;

        public MainWindow()
        {
            InitializeComponent();
            InitializeData();
            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void InitializeData()
        {
            // Beispiel für die Initialisierung von Serviceaufträgen
            serviceAuftraege = new List<ServiceAuftrag>
            {
                // Füge hier deine Beispiel-Serviceaufträge ein
            };
        }

        private async void LoadServiceAuftraegeFromBackend()
        {
            string backendBaseUrl = "http://localhost:5000"; // Hier die richtige Adresse einfügen

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync($"{backendBaseUrl}/api/serviceauftraege");

                    if (response.IsSuccessStatusCode)
                    {
                        var serviceAuftraege = await response.Content.ReadFromJsonAsync<List<ServiceAuftrag>>(); // Änderung hier
                        serviceAuftraege = serviceAuftraege.OrderByDescending(auftrag => auftrag.Prioritaet).ToList();
                        serviceListView.ItemsSource = serviceAuftraege;
                    }
                    else
                    {
                        // Handle Fehler bei der Antwort des Servers
                        MessageBox.Show($"Fehler beim Laden der Serviceaufträge. Statuscode: {response.StatusCode}", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Handle Ausnahmen während der Anfrage
                    MessageBox.Show($"Fehler beim Laden der Serviceaufträge: {ex.Message}", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        // Restlicher Code (Login-Button, PropertyChanged-Event, etc.) bleibt unverändert
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
