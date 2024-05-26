using System.Collections;

namespace GoogleMapsSeleniumCSharp.src.TestData
{
    /// <summary>
    /// Addresses and loactions: German version (local debugging)
    /// </summary>
    public class TestDataDE
    {
        public static IEnumerable<TestCaseData> ValidAddressesDirectionSearch()
        {
            yield return new TestCaseData("Saarbrücker Str. 38, 10405 Berlin", "OZEANEUM, Hafenstraße 11, 18439 Stralsund");
            yield return new TestCaseData("Otto-Flimm-Str, 53520 Nürburg", "Via dei Palchetti, 50123 Firenze FI, Italien");
            yield return new TestCaseData("Gasteiner Strasse 97, Österreich", "Herning, Dänemark");
            yield return new TestCaseData("Europaplatz 1, Berlin", "Rethedamm 12, 21107 Hamburg");
        }

        public static IEnumerable<TestCaseData> MapsCannotComputeTravelRoute()
        {
            yield return new TestCaseData("Berlin", "Australien");
        }

        /// <summary>
        /// Valid address, title in headerline after searching is done
        /// </summary>
        public static IEnumerable<TestCaseData> ValidAddresses()
        {
             yield return new TestCaseData("Budapester Str. 32, 10787 Berlin", "Budapester Str. 32");
             yield return new TestCaseData("7655 Chem. Samuel, Québec, QC G1H 7H4, Canada", "7655 Chem. Samuel");
             yield return new TestCaseData("Bennelong Point, Sydney NSW 2000, Australien", "Bennelong Point");
        }

        /// <summary>
        /// Valid loacations
        /// </summary>
        public static IEnumerable<TestCaseData> Vacations()
        {
                yield return new TestCaseData("Disneyland Orlando", "Florida");
                yield return new TestCaseData("Caerphilly Castle", "Castle St, Caerphilly CF83 1JD, Vereinigtes Königreich");
                yield return new TestCaseData("Semperoper DrEsDeN", "Theaterplatz 2, 01067 Dresden");
        }
    }
}
