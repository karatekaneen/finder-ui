# Gränssnitt för Finder

## Gör så här:

- Börja med att skapa en fork av den här repo:n. Här finns en guide hur man gör: https://help.github.com/en/articles/fork-a-repo
- I er nya fork, bygg det nya gränssnittet där ni implementerar de webbtjänster som behövs osv.

Sedan när ni börjar närma er en stabil version som ni vill publicera till huvudprojektet så börja med att följa anvisningarna i guiden ovan för att synka till huvudprojektet. Finns i [DET HÄR STYCKET](https://help.github.com/en/articles/fork-a-repo#keep-your-fork-synced).
Se sedan till att det fungerar med era nya ändringar även med det som har ändrats i huvudprojektet sedan ni klonade första gången.

Efter att det fungerar med alla nya ändringar så är det dags att försöka få in det i huvudprojektet.

- [Läs den här guiden](https://help.github.com/en/articles/creating-a-pull-request-from-a-fork)
- Var noga med att skriva en bra beskrivning så att vi som kontrollerar kan snabbt och enkelt se vad vi kontrollerar.
- _Håll dig uppdaterad_ i tråden här på github ifall det blir konflikter som blir för jobbiga för oss att snabbt och enkelt ändra kommer mergen att _nekas_ och ni behöver själva lösa konflikterna och göra om processen


# Inloggningsfunktion
För att använda sig av authorization så skriv [CustomAuthorization] ovanför önskad actionmetod eller controller.
För att hämta ID där det behövs, så använd:
```int.TryParse(Session["UserId"].ToString(), out int userid);```

## noteringar ang. uppdatering av profil
För att komma åt uppdatera profil så gå till URLen /account/updateuserprofile
Finns ingen knapp för denna än


