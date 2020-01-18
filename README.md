# Gamma</br>Versiunea pentru client
Gamma este o aplicație web pentru gestionarea activităților didactice din cadrul unităților de învățământ.<br/>
Aplicația este definită pentru 5 roluri: utilizator musafir, membru inactiv, administrator, director general, profesor.

## Crearea unui cont
Administratorul este cel care activează conturile membrilor noi, iar dacă în baza de date nu ar exista un administrator înainte ca un utilizator obișnuit să se înregistreze, contul său nu ar fi activat niciodată. Pentru această situație, am stabilit următoarea convenție: dacă nu există niciun utilizator în sistem, la primul cont creat se creează automat și rolul 'Administrator', iar contul este asignat acestui rolul. 
