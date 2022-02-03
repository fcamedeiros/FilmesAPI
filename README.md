<img src="https://img.shields.io/badge/releasedate-january-orange"/> <img src="https://img.shields.io/badge/status-finalizado-orange"/>

![RoloFilmes](https://user-images.githubusercontent.com/35452578/152268774-aa5f273f-9684-4179-bfe5-d1970404904e.jpg) 

# FilmesAPI
API desenvolvida no curso "API Rest com .Net 5" da Alura cuja persistência de dados ocorre no MySQL e permite o cadastro, busca, alteração e deleção de Filmes. 

## Cadastro
Adiciona um filme no Banco de Dados

### Request
```
POST /Filme
```

### Request Body:
```
{ 
  "titulo" : "string", 
  "genero" : "string", 
  "diretor" : "string", 
  "duracao" : int 
}
```

### Response Body:
```
{
  "id": int,
  "titulo": "string",
  "diretor": "string",
  "genero": "string",
  "duracao": int
}
```

### Status Code:
```
201: Created
400: Bad Request
```

![post](https://user-images.githubusercontent.com/35452578/152438329-26629591-4c92-4012-825f-5b03357005ad.gif)

## Busca
Recupera a lista de filmes presentes no Banco de Dados

### Request
```
GET /Filme
```

### Response Body:
```
[
  {
    "id": int,
    "titulo": "string",
    "diretor": "string",
    "genero": "string",
    "duracao": int
  }
]
```

### Status Code:
```
200: Ok
```

![get_vazio](https://user-images.githubusercontent.com/35452578/152438504-6f4463cd-752f-4a8c-86a0-548886904a2e.gif)

![get](https://user-images.githubusercontent.com/35452578/152438520-1867c519-8e7d-47e8-a2ed-0c2147def208.gif)


## Busca pelo Id
Recupera um filme pelo seu identificador

### Request
```
GET /Filme/{id}
```

### Response Body:
```
{
  "titulo": "string",
  "diretor": "string",
  "genero": "string",
  "duracao": int,
  "horadaconsulta": DateTime
}
```

### Status Code:
```
200: Ok
404: Not Found
```

![getid_vazio](https://user-images.githubusercontent.com/35452578/152438628-4911d799-e126-4f95-ab2c-8a5ddfef40c7.gif)

![getid](https://user-images.githubusercontent.com/35452578/152438644-8d940981-4879-48d1-845f-2f9c418f20af.gif)

## Atualização
Atualiza os dados de um filme cadastrado

### Request
```
PUT /Filme/{id}
```

### Request Body:
```
{
  "titulo": "string",
  "diretor": "string",
  "genero": "string",
  "duracao": int
}
```

### Response Body:
```
```

### Status Code:
```
204: No Content
404: Not Found
```

![putnot](https://user-images.githubusercontent.com/35452578/152438819-46538371-5483-4ac8-b86d-09691766e47d.gif)

![putok](https://user-images.githubusercontent.com/35452578/152438829-cf9cb023-1e8e-428e-9dd3-a653f6430767.gif)

## Deleção
Elimina um filme cadastrado

### Request
```
DELETE /Filme/{id}
```

### Response Body:
```
```

### Status Code:
```
204: No Content
404: Not Found
```

![deletenot](https://user-images.githubusercontent.com/35452578/152438867-4cd4bcdf-179e-4d88-9a08-8943fb6e1ab0.gif)

![deleteok](https://user-images.githubusercontent.com/35452578/152438877-c26a3211-31ee-4b19-b816-8078881d853b.gif)
