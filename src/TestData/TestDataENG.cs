using System.Collections;

namespace GoogleMapsSeleniumCSharp.src.TestData
{
    /// <summary>
    /// Addresses and loactions: english version
    /// </summary>
    public class TestDataENG
    {
        public static IEnumerable ValidAddressesDirectionSearch
        {
            get
            {
                yield return new TestCaseData("Saarbrücker Str. 38, 10405 Berlin", "OZEANEUM, Hafenstraße 11, 18439 Stralsund");
                yield return new TestCaseData("Otto-Flimm-Str, 53520 Nürburg", "Via dei Palchetti, 50123 Firenze FI, Italy"); 
                yield return new TestCaseData("Gasteiner Strasse 97, Austria", "Herning, Denmark");
                yield return new TestCaseData("Europaplatz 1, Berlin", "Rethedamm 12, 21107 Hamburg");
            }
        }

        /// <summary>
        /// Valid address, title in headerline after searching is done
        /// </summary>
        public static IEnumerable ValidAddresses
        {
            get
            {
                yield return new TestCaseData("2-1 Dogenzaka, Shibuya City, Tokyo", "Dogenzaka");
                yield return new TestCaseData("Budapester Str. 32, 10787 Berlin", "Budapester Str. 32");
                yield return new TestCaseData("7655 Chem. Samuel, Québec, QC G1H 7H4, Canada", "7655 Chem. Samuel");
                yield return new TestCaseData("Bennelong Point, Sydney NSW 2000, Australia", "Bennelong Point");
            }
        }

        /// <summary>
        /// Valid loacations
        /// </summary>
        public static IEnumerable Vacations
        {
            get
            {
                yield return new TestCaseData("Disneyland ORLANDO", "Orlando, FL, United States");
                yield return new TestCaseData("opera house sydney", "Bennelong Point, Sydney NSW 2000, Australia");
                yield return new TestCaseData("Caerphilly Castle", "Castle St, Caerphilly CF83 1JD, United Kingdom");
                yield return new TestCaseData("Semperoper DrEsDeN", "Theaterplatz 2, 01067 Dresden");
            }
        }
    }
}
