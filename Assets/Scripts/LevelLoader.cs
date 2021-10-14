using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
	public GameObject[] Levels;
	void Start()
    {
		TooltipSystem.Hide();
		
		//TooltipSystem.Show(GameStartedContent, GameStartedHeader);
		if (SceneManager.GetActiveScene().name == "PrototypeScene")
		{
			for (int a = 0; a < Levels.Length; a++)
				Levels[a].SetActive(false);
			if (PlayerPrefs.GetInt("LevelIDPrototype") < Levels.Length)
				Levels[PlayerPrefs.GetInt("LevelIDPrototype")].SetActive(true);
				if (PlayerPrefs.GetInt("LevelIDPrototype") == 0)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("5 parcalik Ogretici Bolumlerine Hosgeldin! Hadi simdi Kemerini bagla ve Motoru calistir, ardindan da ilerideki Park Yerine aracini park et!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Bienvenue dans les chapitres du didacticiel en 5 parties�! Maintenant, attachez votre ceinture de securite et demarrez le moteur, puis garez votre voiture dans le prochain parking�!", "Parking Master Tutorial"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Bienvenido a los capitulos de tutoriales de 5 piezas! Ahora abroche su cinturon de seguridad y encienda el motor, luego estacione su auto en el proximo estacionamiento! ", " Tutorial del Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("Willkommen zu den 5-teiligen Tutorial-Kapiteln! Jetzt anschnallen und den Motor starten, dann parken Sie Ihr Auto auf dem nachsten Parkplatz!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("Welcome to our 5-part tutorial program. Come on, fasten your seat belt and park your vehicle in the marked area ahead.", "Parking Master Tutorial");
				}else if (PlayerPrefs.GetInt("LevelIDPrototype") == 1)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("Ileriden U-Donusu yap ve ilerideki Park Yerine aracini park et. Etraftaki dubalara da carpmamaya ozen goster, odulunu etkileyecekler!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Prenez le virage devant vous et garez votre voiture sur le parking devant vous. Attention a ne pas heurter les peniches environnantes, elles affecteront votre prix!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Haga un giro en U mas adelante y estacione su automovil en el estacionamiento de adelante. Tenga cuidado de no golpear los pontones, afectaran su premio!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("Machen Sie eine Kehrtwende und parken Sie Ihr Fahrzeug auf dem Parkplatz vor Ihnen. Achten Sie darauf, die Pontons nicht zu treffen, da dies Ihren Preis beeinflusst!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("Make a U-Turn ahead and park your vehicle in the Parking Lot. Be careful, not to hit the pontoons around, they will affect your prize!", "Parking Master Tutorial"); //�NG�L�ZCE
				}
				else if (PlayerPrefs.GetInt("LevelIDPrototype") == 2)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("Artik kurallari biliyorsun. Yolu takip et ve dubalara carpmamaya ozen goster!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Vous connaissez maintenant les regles. Suivez la route et faites attention a ne pas heurter les peniches!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Ahora conoces las reglas. Siga la carretera y tenga cuidado de no golpear las barcazas!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("Jetzt kennen Sie die Regeln. Folgen Sie der StraBe und achten Sie darauf, nicht auf die Kahne zu treffen!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("Now you know the rules. Follow the road and take care not to hit the pontoons!", "Parking Master Tutorial"); //�NG�L�ZCE
				}
				else if (PlayerPrefs.GetInt("LevelIDPrototype") == 3)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("Bunun gibi bazi bolumler sana ELMAS ODULU de verecektir! Ancak Elmas'i sadece 1 kere alabilirsin ve hicbir yere carpmaman gerekiyor!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Certains chapitres comme celui-ci vous donneront egalement le DIAMOND AWARD ! Cependant, vous ne pouvez obtenir Diamond qu une seule fois et vous n avez pas a vous ecraser sur quoi que ce soit!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Algunos capitulos como este tambien te daran el PREMIO DIAMANTE! Sin embargo, solo puede obtener Diamond una vez y no tiene que chocar contra nada!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("Einige Kapitel wie dieses verleihen Ihnen auch den DIAMOND AWARD! Sie konnen Diamond jedoch nur einmal erhalten und mussen mit nichts zusammenstoBen!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("Some chapters like this will also give you the DIAMOND AWARD! However, you can only get Diamond once and you shouldn't crash into anything!", "Parking Master Tutorial"); //�NG�L�ZCE
				}
				else if (PlayerPrefs.GetInt("LevelIDPrototype") == 4)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur! Ayrica Ogreticinin son bolumundesin. Bundan sonra kendine bir arac al ve istedigin bolgede gorevlere basla!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment! Vous etes egalement dans la derniere partie du didacticiel. Apres cela, procurez-vous un vehicule et commencez des missions dans la region de votre choix !", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado! Tambien se encuentra en la ultima parte del Tutorial. Despues de eso, consiguete un vehiculo y comienza misiones en la region que quieras!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig! Sie befinden sich auch im letzten Teil des Tutorials. Besorgen Sie sich danach ein Fahrzeug und starten Sie Missionen in der gewunschten Region!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode! You are also in the last part of the Tutorial. After that, get yourself a vehicle and start missions in the region you want!", "Parking Master Tutorial"); //�NG�L�ZCE
				}
			else if (PlayerPrefs.GetInt("LevelIDPrototype") == Levels.Length)
			{
				SceneManager.LoadScene("MainMenu");
			}
		}
		else if (SceneManager.GetActiveScene().name == "CityScene")
		{
			for (int a = 0; a < Levels.Length; a++)
				Levels[a].SetActive(false);
			if (PlayerPrefs.GetInt("LevelIDCity") < Levels.Length)
				Levels[PlayerPrefs.GetInt("LevelIDCity")].SetActive(true);
				if (PlayerPrefs.GetInt("LevelIDCity") == 3)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("LevelIDCity") == 8)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("LevelIDCity") == 12)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("LevelIDCity") == 20)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("LevelIDCity") == 21)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("LevelIDCity") == 23)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("LevelIDCity") == 25)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("LevelIDCity") == 26)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("LevelIDCity") == 28)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("LevelIDCity") == 33)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("LevelIDCity") == 38)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("LevelIDCity") == 42)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("LevelIDCity") == 44)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("LevelIDCity") == 48)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}
			else if (PlayerPrefs.GetInt("LevelIDCity") == Levels.Length)
				SceneManager.LoadScene("MainMenu");
		}
		else if (SceneManager.GetActiveScene().name == "CitySceneTT")
		{
			for (int a = 0; a < Levels.Length; a++)
				Levels[a].SetActive(false);
			if (PlayerPrefs.GetInt("LevelIDCityTT") < Levels.Length)
				Levels[PlayerPrefs.GetInt("LevelIDCityTT")].SetActive(true);
				if (PlayerPrefs.GetInt("LevelIDCityTT") == 3)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("LevelIDCityTT") == 8)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("LevelIDCityTT") == 12)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("LevelIDCityTT") == 20)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("LevelIDCityTT") == 21)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("LevelIDCityTT") == 23)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("LevelIDCityTT") == 25)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("LevelIDCityTT") == 26)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("LevelIDCityTT") == 28)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("LevelIDCityTT") == 33)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("LevelIDCityTT") == 38)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("LevelIDCityTT") == 42)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("LevelIDCityTT") == 44)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("LevelIDCityTT") == 48)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}
			else if (PlayerPrefs.GetInt("LevelIDCityTT") == Levels.Length)
				SceneManager.LoadScene("MainMenu");
		}
		else if (SceneManager.GetActiveScene().name == "SwampMap")
		{
			for (int a = 0; a < Levels.Length; a++)
				Levels[a].SetActive(false);
			if (PlayerPrefs.GetInt("LevelIDSwamp") < Levels.Length)
				Levels[PlayerPrefs.GetInt("LevelIDSwamp")].SetActive(true);
				if (PlayerPrefs.GetInt("LevelIDSwamp") == 9)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("LevelIDSwamp") == 15)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("LevelIDSwamp") == 17)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("LevelIDSwamp") == 23)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("LevelIDSwamp") == 28)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("LevelIDSwamp") == 30)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("LevelIDSwamp") == 39)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}
			else if (PlayerPrefs.GetInt("LevelIDSwamp") == Levels.Length)
				SceneManager.LoadScene("MainMenu");
		}
		else if (SceneManager.GetActiveScene().name == "SwampMapTT")
		{
			for (int a = 0; a < Levels.Length; a++)
				Levels[a].SetActive(false);
			if (PlayerPrefs.GetInt("LevelIDSwampTT") < Levels.Length)
				Levels[PlayerPrefs.GetInt("LevelIDCSwampTT")].SetActive(true);
				if (PlayerPrefs.GetInt("SwampMapTT") == 9)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("SwampMapTT") == 15)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("SwampMapTT") == 17)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("SwampMapTT") == 23)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("SwampMapTT") == 28)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("SwampMapTT") == 30)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}else if (PlayerPrefs.GetInt("SwampMapTT") == 39)
				{
					if (PlayerPrefs.GetString("_language") == "tr") //T�RK�E
						TooltipSystem.Show("ELMAS Odullu Bolum! Dikkatli Sur!", "Parking Master Ogreticisi"); //T�RK�E
					else if (PlayerPrefs.GetString("_language") == "fr") //FRANSIZCA
						TooltipSystem.Show("Episode prime de DIAMANT�! Conduire prudemment!", "Formation de Parking Master"); //FRANSIZCA
					else if (PlayerPrefs.GetString("_language") == "sp") //�SPANYOLCA
						TooltipSystem.Show("Episodio ganador del premio DIAMOND! Conduce con cuidado!", "Tutorial de Parking Master"); //�SPANYOLCA
					else if (PlayerPrefs.GetString("_language") == "de") //ALMANCA
						TooltipSystem.Show("DIAMOND-preisgekronte Folge! Fahr vorsichtig!", "Parking Master Tutorial"); //ALMANCA
					else
						TooltipSystem.Show("DIAMOND Award-Winning Episode!", "Parking Master Tutorial"); //�NG�L�ZCE
				}
			else if (PlayerPrefs.GetInt("LevelIDCSwampTT") == Levels.Length)
				SceneManager.LoadScene("MainMenu");
		}
		
	}

	public void RestartLevel()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
