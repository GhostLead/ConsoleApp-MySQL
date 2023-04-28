using MySql.Data.MySqlClient;

string kapcsolatLeiro = "datasource=127.0.0.1;port=3306;username=root;password=;database=hardver;charset=utf8";

MySqlConnection SQLkapcsolat = new MySqlConnection(kapcsolatLeiro);

try
{
    SQLkapcsolat.Open();
}
catch (MySqlException hiba)
{

    Console.WriteLine(hiba.Message);
    Environment.Exit(1);
}



//                       1. FELADAT
/*
string SQLlekerdezesKategoriaRendezetten = "SELECT DISTINCT Gyártó FROM termékek GROUP BY Gyártó HAVING COUNT(Kategória = 'monitor') >= 40;";

MySqlCommand SQlparancs = new MySqlCommand(SQLlekerdezesKategoriaRendezetten, SQLkapcsolat);


MySqlDataReader eredmenyOlvaso = SQlparancs.ExecuteReader();


while (eredmenyOlvaso.Read())
{
    Console.WriteLine(eredmenyOlvaso.GetString("Gyártó"));
}

eredmenyOlvaso.Close();

SQLkapcsolat.Close();
*/




//                       2. FELADAT

string SQLlekerdezesKategoriaRendezetten = "SELECT * FROM termékek WHERE Ár > (SELECT Ár FROM termékek WHERE Ár = (SELECT MAX(Ár) FROM termékek WHERE Kategória LIKE 'Winchester%' AND Gyártó LIKE 'Seagate')) AND Kategória LIKE 'Winchester%' ORDER BY `termékek`.`Ár` ASC;";

MySqlCommand SQlparancs = new MySqlCommand(SQLlekerdezesKategoriaRendezetten, SQLkapcsolat);


MySqlDataReader eredmenyOlvaso = SQlparancs.ExecuteReader();


while (eredmenyOlvaso.Read())
{
    string s = "                                    |";
    s += String.Format("{0,9}", eredmenyOlvaso.GetString("Cikkszám") + " | ");
    s += eredmenyOlvaso.GetString("Kategória").PadRight(22) + " | ";
    s += eredmenyOlvaso.GetString("Gyártó").PadRight(15) + " | ";
    s += eredmenyOlvaso.GetString("Név").PadRight(74) + " | ";
    s += eredmenyOlvaso.GetString("Ár").PadRight(6) + "Ft" + " | ";
    s += eredmenyOlvaso.GetString("Garidő").PadRight(2) + " | ";
    s += eredmenyOlvaso.GetString("Készlet").PadRight(12) + " | ";
    s += eredmenyOlvaso.GetString("Súly").PadRight(5) + " | ";
    Console.WriteLine(s);
}

eredmenyOlvaso.Close();

SQLkapcsolat.Close();



