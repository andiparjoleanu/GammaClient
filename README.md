# Gamma</br>Versiunea pentru client
Gamma este o aplicație web pentru gestionarea activităților didactice din cadrul unităților de învățământ.<br/>
Aplicația este definită pentru 5 categorii de utilizatori: utilizator musafir, membru inactiv, administrator, director general, profesor.

## Crearea unui cont
Administratorul este cel care activează conturile membrilor noi, iar dacă în baza de date nu ar exista un administrator înainte ca un utilizator obișnuit să se înregistreze în sistem, contul său nu ar fi activat niciodată. Pentru această situație, am stabilit următoarea convenție: dacă nu există niciun utilizator înregistrat în baza de date, la primul cont creat se creează automat și rolul 'Administrator', iar contul este asignat acestui rolul. 

## Roluri în aplicație
### Utilizatorul musafir
Un utilizator musafir are acces la pagina de prezentare și poate să-și creeze un cont în aplicație.

### Membrul inactiv
Membrul inactiv este utilizatorul care și-a creat cont în aplicație și care nu are un rol asignat. Acesta are aceleași drepturi ca utilizatorul musafir.

### Administratorul
Un administrator poate să creeze roluri noi și să activeze conturi prin asignarea lor unui rol existent.

### Directorul general
Directorul general poate să înregistreze instituții de învățământ în sistem și să asocieze membri înregistrați acestor instituții. De asemenea, are drept de editare a informațiilor membrilor.

### Profesor
Un profesor poate să creeze cursuri, să înscrie studenți eligibili la curs și să atribuie studenților note pentru activitatea realizată în cadrul cursului. Profesorul primește aceste drepturi doar dacă un director general asociază contul profesorului cu o instituție înregistrată în sistem și cu un departament existent din cadrul instituției, întrucât cursurile sunt definite pentru un anumit domeniu de studiu și pentru o anumită grupă de studenți.

## În curând
### Rolul student
Studentul va putea să vadă detalii despre cursurile la care este înscris.
