# HastEmail-Client
Simple client in C# for HastEmail API

![Demo](https://i.imgur.com/eYv6KLG.png)


[API](https://bit.ly/2yv3qGb) | [ISSUE](https://bit.ly/2zdu06I) | [HEROKU](https://bit.ly/2SBDI9V)

## Index
- [Specifica del Progetto](#specifica-del-progetto)
- [Architettura e Sviluppatore](#architettura-e-informazioni-sullo-sviluppatore)
- [Servizi esterni utlizzati](#servizi-esterni-utlizzati)
- [About HastEmail Client](#about-hastemail-client)
- [Licenza](#licenza)

-----------
### Specifica del Progetto
Il progetto consiste nella realizzazione di un client per la gestione di filtro mail, sviluppato secondo l’architettura RESTful. L’API (server-side) gestisce un database locale, catalogando tutte le e-mail considerate “spam” o malicious in un file JSON.
<br>
<br>
L’API accetta richieste HTTP di tipo GET e POST, rispettivamente utilizzate per controllare se una mail (o più mail) è presente nella blacklist e per la fase di autenticazione, senza richiedere particolari requisiti.
I metodi PATCH e DELETE, utilizzati rispettivamente per aggiungere o rimuovere una mail, vengono, invece, protetti con la basic-authentication (over-https), in quanto unicamente l’amministratore dell’API ha diritto all’utilizzo. 
<br>
<br>
Per una comoda gestione dell’API, si è quindi scelto di creare un client C#, che aiuti nell’ordinaria amministrazione, e che consenta di gestire i vari metodi anche da remoto, così da aggiungere e rimuovere le diverse e-mail all’interno della blacklist.

-----------
### Architettura e informazioni sullo sviluppatore
L'architettura è stata scelta basandosi sul modello API-RESTful implementato nella parte server-side. Per migliorare la grafica dei windows form, si è scelto di implementare il framework *MetroFramework*, il quale consente di gestire i form in maniera più semplice, e offre degli *oggetti natii*. 

About | Description
--- | --- 
`Developer` | *Jacopo M. Mengarelli (LitteZen)*
`Matricola` | *292728*
`Language` | *C#*
`Framework` | *MetroFramework*
`Release Version` | *1.0*
`Last Version` | *1.4*


###### * = La repository `API` è disponibile [QUI](https://github.com/Zenek-Hastro/Hastemail)  
-----------
### Servizi esterni utlizzati
L'app è stata configurata per funzionare su Heroku (vedi documentazione API). Heroku è un servizio web, che oltre a consentire l'hosting gratuito dell'api, fornisce certificati HTTPS essenziali nelle fasi di autenticazione. Il client ha fatto uso di un Framework esterno ( già ampiamente presentato), e di una libreria esterna per la gestione dei file JSON.

About | Description
--- | --- 
`MetroFramework` | *Windows form framework by Jens Thiel*
`Newtonsoft Json` | *Json Lib used for correctly parse Json files*

-----------
### About HastEmail Client
Il programma si compone di due form principali. Il primo richiede l'autenticazione (utilizzata successivamente per validare alcuni metodi API), il secondo è il "main form" utilizzato per gestire e visualizzare le richieste/risposte al/del server.

#### LoginForm Access
![Screenshot Login](https://i.imgur.com/gZ1u0cs.png)
![Screenshot Login Fail](https://i.imgur.com/JeKViFR.png)


Il login form, è utilizzato per autenticare l'utente. Invia una richiesta all'api, la quale mediante la basic authentication consente di validare o meno l'utente. La textbox "password" nasconde i caratteri per proteggere la password. In caso di inserimento di credenziali errate, il form diventa rosso e prenseta una *label di errore* (come presentato nel secondo screenshot)


#### MainForm
![Main Form Check One Email](https://i.imgur.com/5MMWUaD.png)
![Main Form Check Blacklist](https://i.imgur.com/VgG8JTH.png)
![Main Form Add email](https://i.imgur.com/cqGw2D0.png)
![Main Form Remove email](https://i.imgur.com/WN3NmhD.png)
![Main Form Settings](https://i.imgur.com/OOQZPtB.png)


- `Check One Email`: Tab che consente di inviare una mail al server e verifica che non sia presente il blacklist
- `Check BlackList`: Tab che consente di visualizzare tutta la blacklist mediante la stampa nella textbox
- `Add Email`: Tab che consente di aggiungere una mail alla blacklist
- `Remove Email`: Tab che consente di rimuovere una mail dalla blacklist
- `Settings`: Tab che consente di visualizzare impostazioni e informazioni
-----------
### Licenza
Per la scelta della licensa si è scelto di utilizzare il servizio "https://choosealicense.com/", che sulla base delle informazioni fornite, e cioè sulla necessità di mentenere il codice più aperto e utilizzabile possibile, ha suggerito l'implementazione della licenza GNU V3

-----------
