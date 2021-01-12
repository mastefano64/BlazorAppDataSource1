# BlazorAppDataSource1

Il progetto su GitHub contiene 6 esempi di griglia rispettivamente denominate: Grid1, Grid2, Grid3, Grid4 Grid5, Grid6.
 
Le griglie Grid1, Grid2, Grid3 implementano una paginazione lato client utilizzando il datasource “DataSourceClient”.
 
Le griglie Grid4, Grid5, Grid6 implementano una paginazione lato server client utilizzando il datasource “DataSourceServer”.
 
In entrambe le tipologie è presente: “un esempio di paginazione tramite bottoni”, “un esempio di paginazione tramite barra di navigazione”,  “un esempio di paginazione tramite barra di navigazione e form per operazioni CRUD”. Sotto si può trovare un estratto della griglia 3.
 
DataSourceClient e DataSourceServer
 
Sotto si possono vedere le principali proprietà ed i metodi della classe “BaseDataSource”. Per maggiori informazioni si rimanda al codice presente nel progetto su GitHub.
   
Result, Count>
Page, MinPage, MaxPage, Pagesize, OrderbyColumn, OrderbyDirection
HasFirstPage, HasPrevPage, HasNextPage, HasLastPage
FirstPage, PrevPage, NextPage, LastPage
LoadPaggedData( … ), GotoPage(int page)
GotoFirstPage(), GotoPrevPage(), GotoNextPage(), GotoLastPage()
SortByColumn( … )
Refresh()
