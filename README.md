# 🐾 Gestionale per Clinica Veterinaria

Questo gestionale è pensato per rispondere alle esigenze quotidiane di una **clinica veterinaria**, permettendo una gestione ordinata e intuitiva di animali, clienti, visite, ricoveri e farmacia.  
L’accesso al sistema è regolato da una schermata di **login**, e solo gli utenti con privilegi **admin** possono accedere alle sezioni principali dell’applicazione.

Una volta effettuato il login come amministratore, si ha accesso a diverse sezioni:

---

## 🔸 Gestione degli Animali (Puppies)

In questa sezione è possibile consultare una **tabella completa di tutti gli animali** registrati nella clinica. Per ciascun animale sono visibili informazioni come:

- la **data di nascita**
- il **colore del pelo**
- la **razza**
- il nome del **proprietario**

L’interfaccia consente di **aggiungere un nuovo animale**, **modificare i dati**, **eliminarlo** o **visualizzarne i dettagli**.  
Tutte queste azioni vengono eseguite tramite **modali**, che si aprono sovrapponendosi alla pagina, evitando così il cambio di vista e mantenendo l’esperienza utente fluida.

---

## 🔸 Visite

Anche la sezione dedicata alle **visite** segue una struttura simile a quella degli animali: è presente un elenco completo di tutte le visite effettuate presso la clinica, con la possibilità di:

- aggiungere una nuova visita
- modificarla
- eliminarla
- visualizzare i dettagli

Anche in questo caso, ogni azione viene eseguita attraverso comode **modali**.

---

## 🔸 Ricoveri

La sezione **ricoveri** permette di gestire i pazienti che richiedono degenza.  
È possibile visualizzare l’elenco completo dei ricoveri e **filtrarli** tra quelli **attualmente attivi** e quelli **già conclusi**.

Come per le altre sezioni, è possibile:
- aggiungere un nuovo ricovero
- modificarlo
- eliminarlo
- consultare i dettagli

Ogni operazione avviene tramite **modale**, garantendo coerenza nell’esperienza d’uso.

---

## 🔸 Clienti

La sezione clienti è progettata per gestire in modo semplice e veloce tutte le informazioni relative ai proprietari degli animali.  
Si può visualizzare l’elenco dei clienti e per ciascuno:

- aggiungere un nuovo cliente
- modificarne i dati
- eliminarlo
- visualizzare i dettagli

Anche qui tutte le operazioni vengono gestite tramite **modali**.

---

## 🔸 Farmacia Interna

La farmacia è suddivisa in tre sotto-sezioni:

### ▪ Prodotti

Mostra un elenco dei **prodotti farmaceutici** disponibili in clinica.  
Per ogni prodotto è possibile:
- aggiungerlo
- modificarlo
- eliminarlo
- consultarne i dettagli

Le azioni vengono sempre gestite tramite **modali**.

---

### ▪ Vendite

In questa sezione si trova l’elenco di tutte le **vendite effettuate**.  
Oltre a poter **aggiungere, modificare ed eliminare** una vendita, è presente una **funzionalità di ricerca avanzata**:

- per **codice fiscale** del cliente
- per **data di acquisto**

---

### ▪ Fornitori

Questa pagina raccoglie l’elenco dei **fornitori** della clinica.  
Come nelle altre sezioni, è possibile:
- aggiungere un fornitore
- modificarne i dati
- eliminarlo

Anche in questo caso, tutto avviene tramite **modali**.

---

##  Cerca il tuo Puppy (accesso pubblico)

È disponibile una pagina pubblica, **senza necessità di login**, dove i proprietari possono cercare il proprio animale in caso di **smarrimento**.  
La ricerca avviene tramite il **numero di microchip**, ed è pensata per essere semplice e immediata, accessibile da chiunque.

---

## ⚙️ Tecnologie utilizzate

- **Frontend**: React con redux
  (collegamento repository:https://github.com/rachelebarberis/build-week-5 )
- **Backend**: ASP.NET Core con C#, Identity e Serilog
- **Database**: SQL Server Management Studio (SSMS)

  ## Autori
   - Vittorio Turiaci
  - Rachele Barberis
  - Osama Ennabati



---


