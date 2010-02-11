Project P3
==========

* Project Leider:  Chris Mens
* Quality Manager: Pieter Kokx
* Rapporteur:      Bram Laar
* Archivaris:      Jeroen van Geel
* Overige Leden:   Rens Joosten

AI Engine
---------
Een AI (Arteficial Intelligence) Engine, die de intelligentie heeft om zo weinig mogelijk opstoppingen te veroorzaken. Deze communiceert met de hardware interface om informatie over de huidige situatie te krijgen.


Web Interface
-------------
De web interface heeft 2 doelen: Direct de hardware aansturen, of de AI Engine aanwijzingen en regels geven.

- De web interface heeft hogere rechten, 'human intelligence' gaat boven de AI.
- De web interface kan de regels (wetten) van de 'hardware layer' niet overtreden.
- De web interface moet door leken te gebruiken zijn.


Hardware Interface
------------------
Abstracte Interface voor communicatie met de hardware (de echte wereld/verkeer)

- Implementeerd regels (wetten), zodat verkeer *nooit* kan botsen.
- Heeft een verbinding met de hardware, en communiceert hiermee.
