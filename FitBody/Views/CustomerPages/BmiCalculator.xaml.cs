namespace BmiCalculator
{
    public partial class MainPage : ContentPage
    {
        const double UnderWeight = 18.5;
        const double NormalWeight = 24.9;
        const double OverWeight = 29.9;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var heightInMeter = double.Parse((heightSlider.Value).ToString()) / 100;
            var weight = double.Parse((weightSlider.Value).ToString());
            var age = double.Parse((ageSlider.Value).ToString());

            var bmi = weight / (heightInMeter * heightInMeter);
            string result = BmiResult(bmi);

            BMI.Text = bmi.ToString("F2");
            YWS.Text = BmiResult(bmi);
        }



        private string BmiResult(double formula)
        {
            if (formula < UnderWeight)
            {
                return "You are UnderWeight";
            }

            else if (formula <= NormalWeight)
            {
                return "You have Normal Weight";
            }

            else if (formula <= OverWeight)
            {
                return "You are OverWeight";
            }

            else
            {
                return "You are Obese";
            }
        }
    }
}
