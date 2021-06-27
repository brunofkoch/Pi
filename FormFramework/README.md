author: Pablo J. Santos --> @_jaysaints

# FormFramework


1. No arquivo __app.config__ configure a String de Conexão com o banco de dados.  
````
<connectionStrings>
	<add name="MyContext" providerName="System.Data.SqlClient" connectionString="Server=;Database=;Integrated Security=True;" />
</connectionStrings>
````
	+ Copie o codigo acima e cole dentro do aquivo app.config abaixo do bloco `<configSections>...</configSections>` 
	+ No campo Server= coloque o nome da suas instancia do SQL Server;  
	+ No campo Database= coloque o nome do seu banco de dados existente na instancia do SQL Server;

2. Na solução _FormFramework_ click com o lado direito do mouse e vá em `Adicionar>Item existente...`  insira todos os arquivos contido no repositório baixado;

3. Vá até o Console do Gerenciador de Pacotes e execute os comandos abaixo:  
`> Enable-Migrations`  
`> Add-Migration InitialInsert`  
`> Update-Database`  

4. Salve tudo;

5. Pronto agora já pode starta a aplicação!