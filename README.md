# BlazorAppDataSource1

Il progetto su GitHub contiene 6 esempi di griglia rispettivamente denominate: Grid1, Grid2, Grid3, Grid4 Grid5, Grid6.
 
Le griglie Grid1, Grid2, Grid3 implementano una paginazione lato client utilizzando il datasource “DataSourceClient”.
 
Le griglie Grid4, Grid5, Grid6 implementano una paginazione lato server client utilizzando il datasource “DataSourceServer”.
 
In entrambe le tipologie è presente: “un esempio di paginazione tramite bottoni”, “un esempio di paginazione tramite barra di navigazione”,  “un esempio di paginazione tramite barra di navigazione e form per operazioni CRUD”. Sotto si può trovare un estratto della griglia 3.

- IMPORTANTE: I dati visualizzati sono stati creati attraverso un generatore di nomi casuale, pertanto non sono legati a nessuna persona reale.

![example1](/BlazorAppDataSource1/exemple1.png)

L’immagine sovrastante mostra la pagina web in cui viene visualizzata una lista, sulla parte sovrastante è presente una barra di navigazione, a lato dei nomi delle colonne si possono vedere 2 fraccettine mediante le quali è possibile variare l’ordinamento.

![example2](/BlazorAppDataSource1/exemple2.png)

![example3](/BlazorAppDataSource1/exemple3.png)

Le 2 immagini sovrastanti mostrano il template HTML ed il relativo codice C# corrispondente. Come si può vedere il codice C# è minimo, la logica è stata traferita nella classe “DataSourceClient”. Nel momento in cui viene creata la classe “DataSourceClient” Vengono passati come parametro un oggetto “AppStudentiSearch” che contiene i cambi oggetto della ricerca, ed un oggetto “StudentiService” che contiene i metodi che effettuano le chiamate http.
 
## DataSourceClient e DataSourceServer

E’ possibile implementare una paginazione lato client o lato server. Nella paginazione lato client la chiamata iniziale ritorna tutti i dati, nel momento in cui paginiamo non vengono più effettuate chiamate al server.  Nella paginazione lato server la chiamata iniziale ritorna il numero totale di record e gli elementi presenti nella pagina corrente, nel momento in cui paginiamo viene effettuata una chiamata al server che ritorna gli elementi presenti nella pagina richiesta.
 
Sotto si possono vedere le principali proprietà ed i metodi della classe “BaseDataSource”. Per maggiori informazioni si rimanda al codice presente nel progetto su GitHub.
  
 List<TViewModel> Result 
 
 int Count 
 
 int Page
 
 int MinPage
 
 int MaxPage
 
 int Pagesize
 
 string OrderbyColumn
 
 string OrderbyDirection
 
 bool HasFirstPage
 
 bool HasPrevPage
 
 bool HasNextPage
 
 bool HasLastPage
 
 int FirstPage
 
 int PrevPage
 
 int NextPage
 
 int LastPage
 
 Task LoadPaggedData(int page, int pagesize, string orderbycolumn, string orderbydirection = "asc")
 
 Task<bool> GotoPage(int page)
 
 Task<bool> GotoFirstPage()
 
 Task<bool> GotoPrevPage()
 
 Task<bool> GotoNextPage()
 
 Task<bool> GotoLastPage()
 
 Task<bool> SortByColumn(string column, string direction = "asc") 
 
 Task<bool> Refresh()
 
 Refresh()
