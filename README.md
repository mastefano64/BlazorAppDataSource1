# BlazorAppDataSource1

Il progetto su GitHub contiene 6 esempi di griglia rispettivamente denominate: Grid1, Grid2, Grid3, Grid4 Grid5, Grid6.
 
Le griglie Grid1, Grid2, Grid3 implementano una paginazione lato client utilizzando il datasource “DataSourceClient”.
 
Le griglie Grid4, Grid5, Grid6 implementano una paginazione lato server client utilizzando il datasource “DataSourceServer”.
 
In entrambe le tipologie è presente: “un esempio di paginazione tramite bottoni”, “un esempio di paginazione tramite barra di navigazione”,  “un esempio di paginazione tramite barra di navigazione e form per operazioni CRUD”. Sotto si può trovare un estratto della griglia 3.

![example1](/BlazorAppDataSource1/BlazorAppDataSource1/example1.png)

![example2](/BlazorAppDataSource1/BlazorAppDataSource1/example2.png)

![example3](/BlazorAppDataSource1/BlazorAppDataSource1/example3.png)
 
## DataSourceClient e DataSourceServer
 
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
