using System.Speech.Synthesis;
using System.Windows;

namespace TextToVoice
{
    // In windows können alle Sprachen hinzugefügt werden, die Sprachausgabe unterstützen. (Mikrophon-Symbol)
    public partial class MainWindow : Window
    {
        private SpeechSynthesizer? synthesizer;   //Felder
        private List<InstalledVoice>? voiceList;

        public MainWindow()  //Konstruktor
        {
            InitializeComponent();

            synthesizer = new SpeechSynthesizer();
            this.synthesizer = null;
            this.voiceList = null;
            
            SetVoiceRates();

            bool rv = LoadInstalledVoices();
            InitializeEnabledState(rv);        
        }


        //Geschwindigkeiten
        private void SetVoiceRates()
        {
            cboRate.Items.Add("Very slow");
            cboRate.Items.Add("Slower");
            cboRate.Items.Add("Normal");
            cboRate.Items.Add("Faster");
            cboRate.Items.Add("Very Fast");

            cboRate.SelectedIndex = 2;  //Startwert der aus der Liste ausgewählt wird
        }

        private int GetVoiceRate()
        {
            int voiceRate = 0;
            switch (this.cboRate.SelectedValue)
            {
                case "Very slow": voiceRate = -7; break;
                case "Slower": voiceRate = -2; break;
                case "Normal": voiceRate = 2; break;
                case "Faster": voiceRate = 4; break;
                case "Very fast": voiceRate = 7; break;
            }
            return (voiceRate);
        }



        //Von windows bereitgestellte Stimmen
        private bool LoadInstalledVoices()
        {
            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {
                voiceList = new List<InstalledVoice>();
                foreach (InstalledVoice voice in synth.GetInstalledVoices())
                {
                    voiceList.Add(voice);
                    cboVoices.Items.Add($"{voice.VoiceInfo.Name}-" + $"{voice.VoiceInfo.Gender}-{voice.VoiceInfo.Culture}");
                }
                if (voiceList.Count == 0)
                    return (false);
            }

            cboVoices.SelectedIndex = 0;  //Erste Stimme in der Liste auswählen
            return (true);

        }

        private void InitializeEnabledState(bool state)
        {
            if (state == false)
            {
                MessageBox.Show("Missing: Installed Voices");
            }
            //All die state-booleans werden auf true gestetzt, wenn das VoicePack auch vorhanden ist.
            // Der Pause-Button und der Selection-Button werden noch nicht aktiviert weil sie bei Start noch diesen
            // Zustand einnehmen sollen.
            //Wenn kein VoicePack vorhanden ist, werden die state-booleans alle auf false gesetzt.
            this.BtnSay.IsEnabled = state;
            this.BtnPause.IsEnabled = false;
            this.BtnStop.IsEnabled = state;
            this.BtnClear.IsEnabled = state;
            this.BtnPlaySelection.IsEnabled = false;
        }



        private string? GetVoiceName()
        {
            if (this.cboVoices.Items.Count == 0)
            {
                MessageBox.Show("You must first install some voices");
                return null;
            }
            if (this.cboVoices.SelectedIndex < 0)
            {
                MessageBox.Show("You must first install some voices");
                return null;
            }
            else
            {
                string cboVoiceValue = (string)this.cboVoices.SelectedItem;
                var buckets = cboVoiceValue.ToString().Split("-");

                if (voiceList != null)
                {
                    for (int j = 0; j < voiceList.Count; j++)
                    {
                        var _v = voiceList[j];
                        var v_o = _v.VoiceInfo.Name.ToString().Trim().ToLower();
                        var v_b = buckets[0].ToString().Trim().ToLower();
                        if (v_o == v_b)
                            return (_v.VoiceInfo.Name.ToString());

                    }
                }
                return null;
            }
        }



        //Intitialisierung des Synthesizers und den dazugehörigen Methoden    (System.Speech.Synthesis)
        private void InitializeSynthesizer()
        {
            this.synthesizer = new SpeechSynthesizer(); //neue Instanz
            this.synthesizer.StateChanged += Synthesizer_StateChanged;      //delegates
            this.synthesizer.SpeakCompleted += Synthesizer_SpeakCompleted;
            this.synthesizer.SpeakProgress += Synthesizer_SpeakProgress;
            this.synthesizer.SelectVoice(GetVoiceName());
            this.synthesizer.Rate = GetVoiceRate();
        }




        //EventHandler Zustandsänderung zu Pause
        private void Synthesizer_StateChanged(object? sender, StateChangedEventArgs e)
        {
            switch (e.State)
            {
                case SynthesizerState.Paused:
                    if (this.synthesizer != null)
                    {
                        this.synthesizer.Pause();
                    }
                    break;
            }
        }

        //Synthesizer Dispose Methode (kommt doch sehr häufig vor im code)

        private void DisposeSynth()
        {
            if (this.synthesizer != null)  //this.synthesizer ist eine Instanzvariable und muß nicht extra übergeben werden.
            {
                this.synthesizer.Dispose();
                this.synthesizer = null;
            }
        }

        //EventHandler - Sprachausgabe beendet
        private void Synthesizer_SpeakCompleted(object? sender, SpeakCompletedEventArgs e)
        {
            //if (this.synthesizer != null)
            //{
            //    this.synthesizer.Dispose();
            //    this.synthesizer = null;
            //}

            DisposeSynth();

            this.BtnPause.Content = "Pause";
            this.BtnSay.IsEnabled = true;
            this.info.Text = String.Empty;
            this.Input.IsInactiveSelectionHighlightEnabled = false;
            this.cboVoices.IsEnabled = true;
            this.cboRate.IsEnabled = true;

            if (this.Input.SelectedText.Length > 0)
                this.BtnPlaySelection.IsEnabled = true;
            else
                this.BtnPlaySelection.IsEnabled = false;
        }



        //EventHandler - Fortschritt Sprachausgabe
        private void Synthesizer_SpeakProgress(object? sender, SpeakProgressEventArgs e)
        {
            info.Text = e.Text.ToString();

            if (BtnPlaySelection.IsEnabled == false)
            {
                this.Input.Focus();
                this.Input.Select(e.CharacterPosition, e.Text.Length);
            }
            else
            {
                this.Input.Focus();
                this.Input.Select(this.Input.SelectionStart, this.Input.SelectionLength);
            }

        }



        //Fontsize Änderung
        private void BtnFontSmaller_Click(object sender, RoutedEventArgs e)
        {
            if (Input.FontSize > 10)
            {
                Input.FontSize = Input.FontSize - 2;
            }
        }

        private void BtnFontBigger_Click(object sender, RoutedEventArgs e)
        {
            if (Input.FontSize < 60)
            {
                Input.FontSize = Input.FontSize + 2;
            }
        }



        //EventHandler - Play Button
        private void BtnSay_Click(object sender, RoutedEventArgs e)
        {
            //if (synthesizer != null)
            //{
            //    synthesizer.Dispose();
            //    synthesizer = null;
            //}
            DisposeSynth();

            if (Input.Text.ToString().Trim().Length == 0)
            {
                MessageBox.Show("please provide some text in the Input-Box to continue");
                return;
            }
            InitializeSynthesizer();
            if (synthesizer != null)
            {                
                synthesizer.SpeakAsync(this.Input.Text);
            }

            this.cboVoices.IsEnabled = false;
            this.cboRate.IsEnabled = false;
            this.BtnPause.IsEnabled = true;
            this.BtnPlaySelection.IsEnabled = false;
        }




        //EventHandler - Pause Button
        private void BtnPause_Click(object sender, RoutedEventArgs e)
        {
            if (BtnPause.Content.ToString() == "Pause")
            {
                if (this.synthesizer != null)
                {
                    this.BtnSay.IsEnabled = false;
                    this.synthesizer.Pause();
                    this.BtnPause.Content = "Resume";
                }
            }
            else if (BtnPause.Content.ToString() == "Resume")
            {
                if (this.synthesizer != null)
                {
                    this.BtnSay.IsEnabled = true;
                    this.synthesizer.Resume();
                    this.BtnPause.Content = "Pause";
                }
            }
        }



        //EventHandler - Auswahl abspielen
        private void BtnPlaySelection_Click(object sender, RoutedEventArgs e)
        {
            if (this.Input.SelectionLength > 0)
            {
                PlaySelectedText(this.Input.SelectedText.ToString());
            }
        }



        //Helper Methode zum Abspielen des markierten Textes
        private void PlaySelectedText(string selectedText)
        {
            //if (synthesizer != null)
            //{
            //    synthesizer.Dispose();
            //    synthesizer = null;
            //}

            DisposeSynth();

            InitializeSynthesizer();
            if (this.synthesizer != null)
            {
                this.synthesizer.SpeakAsync(selectedText);
            }
        }



        //EventHandler Stop Button
        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            this.BtnPause.Content = "Pause";
            this.BtnPause.IsEnabled = false;
            this.BtnSay.IsEnabled = true;
            this.info.Text = String.Empty;
            this.Input.IsInactiveSelectionHighlightEnabled = false;
            this.cboVoices.IsEnabled = true;
            this.cboRate.IsEnabled = true;
            this.BtnPlaySelection.IsEnabled = false;
            this.Input.SelectionLength = 0;
            this.Input.SelectionStart = 0;

            //if (this.synthesizer != null)
            //{
            //    this.synthesizer.Dispose();
            //    this.synthesizer = null;
            //}
            DisposeSynth();

        }



        //EventHandler - Textbox leeren
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            this.Input.Text = String.Empty;
            this.BtnSay.IsEnabled = true;
            this.BtnPause.Content = "Pause";
            this.info.Text = String.Empty;
            this.Input.SelectedText = String.Empty;
            this.cboVoices.IsEnabled = true;
            this.cboRate.IsEnabled = true;
            this.BtnPlaySelection.IsEnabled = true;

            //if (this.synthesizer != null)
            //{
            //    this.synthesizer.Dispose();
            //    this.synthesizer = null;
            //}

            DisposeSynth() ;
        }




        // EventHandler - Markieren von Textbereich mit Maus wobei das Lösen des linken Mausbutton(PreviewMouseUp)
        // das Ende der Markierung bedeutet und falls der markierte Bereich länger als 0 ist
        // und der Synthesizer zur Zeit keine Sprachausgabe ausführt,gibt es auch Text der vorgelesen werden kann und die Button werden aktiviert.
        private void Input_PreviousMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (this.synthesizer == null)
            {
                if (this.Input.SelectedText.Length > 0)
                {
                    BtnPlaySelection.IsEnabled = true;
                }
                else
                {
                    BtnPlaySelection.IsEnabled = false;
                }
            }
            else
            {
                BtnPlaySelection.IsEnabled = false;
            }
        }
    }
}