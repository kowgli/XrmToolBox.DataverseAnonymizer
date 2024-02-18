using System.Linq;

namespace XrmToolBox.DataverseAnonymizer.DataSources
{
    public class BogusLocale
    {
        public BogusLocale(string name, string friendlyName)
        {
            this.Name = name;
            this.FriendlyName = friendlyName;
        }

        public string Name { get; set; }
        public string FriendlyName { get; set; }

        public static BogusLocale[] Get()
        {
            return new BogusLocale[]
            {
                new BogusLocale("af_ZA","Afrikaans"),
                new BogusLocale("fr_CH","French (Switzerland)"),
                new BogusLocale("ar","Arabic"),
                new BogusLocale("ge","Georgian"),
                new BogusLocale("az","Azerbaijani"),
                new BogusLocale("hr","Hrvatski"),
                new BogusLocale("cz","Czech"),
                new BogusLocale("id_ID","Indonesia"),
                new BogusLocale("de","German"),
                new BogusLocale("it","Italian"),
                new BogusLocale("de_AT","German (Austria)"),
                new BogusLocale("ja","Japanese"),
                new BogusLocale("de_CH","German (Switzerland)"),
                new BogusLocale("ko","Korean"),
                new BogusLocale("el","Greek"),
                new BogusLocale("lv","Latvian"),
                new BogusLocale("en","English"),
                new BogusLocale("nb_NO","Norwegian"),
                new BogusLocale("en_AU","English (Australia)"),
                new BogusLocale("ne","Nepalese"),
                new BogusLocale("en_AU_ocker","English (Australia Ocker)"),
                new BogusLocale("nl","Dutch"),
                new BogusLocale("en_BORK","English (Bork)"),
                new BogusLocale("nl_BE","Dutch (Belgium)"),
                new BogusLocale("en_CA","English (Canada)"),
                new BogusLocale("pl","Polish"),
                new BogusLocale("en_GB","English (Great Britain)"),
                new BogusLocale("pt_BR","Portuguese (Brazil)"),
                new BogusLocale("en_IE","English (Ireland)"),
                new BogusLocale("pt_PT","Portuguese (Portugal)"),
                new BogusLocale("en_IND","English (India)"),
                new BogusLocale("ro","Romanian"),
                new BogusLocale("en_NG","Nigeria (English)"),
                new BogusLocale("ru","Russian"),
                new BogusLocale("en_US","English (United States)"),
                new BogusLocale("sk","Slovakian"),
                new BogusLocale("en_ZA","English (South Africa)"),
                new BogusLocale("sv","Swedish"),
                new BogusLocale("es","Spanish"),
                new BogusLocale("tr","Turkish"),
                new BogusLocale("es_MX","Spanish (Mexico)"),
                new BogusLocale("uk","Ukrainian"),
                new BogusLocale("fa","Farsi"),
                new BogusLocale("vi","Vietnamese"),
                new BogusLocale("fi","Finnish"),
                new BogusLocale("zh_CN","Chinese"),
                new BogusLocale("fr","French"),
                new BogusLocale("zh_TW","Chinese (Taiwan)"),
                new BogusLocale("fr_CA","French (Canada)"),
                new BogusLocale("zu_ZA","Zulu (South Africa)")
            }
            .OrderBy(l => l.FriendlyName).ToArray();
        }
    }
}
