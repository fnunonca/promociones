<template>
   <v-main>
        <v-card class="mx-auto mt-5" max-width="1200">
            <v-btn rounded color="green accent-2" v-on:click="nuevo">Generar Promocion</v-btn>  
            <v-btn rounded color="yellow accent-2" v-on:click="canjear">Canjear Codigo</v-btn>  
            <v-simple-table class="mt-5">
                <template v-slot:default>
                <thead>
                    <tr class="light-blue darken-2">
                    <th class="white--text">Identificador</th>
                    <th class="white--text">nombre</th>
                    <th class="white--text">email</th>
                    <th class="white--text">codigo</th>
                    <th class="white--text">estado</th>
                    <th class="white--text">Acciones</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="promocion in promociones" :key="promocion.id">
                    <td>{{ promocion.id }}</td>
                    <td>{{ promocion.nombre }}</td>
                    <td>{{ promocion.email }}</td>
                    <td>{{ promocion.codigo }}</td>
                    <td>{{ promocion.estadoDescripcion }}</td>
                    <td>
                        <v-btn class="cyan darken-2" dark v-on:click="editar(promocion.id,promocion.nombre,promocion.email,promocion.codigo, promocion.estado)">Editar</v-btn>
                        <v-btn class="light-blue darken-2" dark v-on:click="eliminar(promocion.id)">Eliminar</v-btn>
                    </td>
                    </tr>
                </tbody>
                </template>
            </v-simple-table>

            <v-dialog v-model="dialog" max-width="900">
                <v-card>
                    <v-card-title class="blue-grey darken-1 white--text">Promocion</v-card-title>
                    <v-card-text>
                        <v-form>
                            <v-container>
                                <v-row>
                                    <v-col cols="12" md="4">
                                        email
                                    </v-col>
                                    <v-col cols="12" md="5">
                                        nombre
                                    </v-col>                                    
                                    <v-col cols="12" md="1">
                                        estado
                                    </v-col>                                    
                                    <v-col cols="12" md="2">
                                        codigo
                                    </v-col>                                        
                                </v-row>                                
                                <v-row>
                                    <input v-model="promocion.id" hidden>
                                    <v-col cols="12" md="4">
                                        <v-text-field v-model="promocion.email" label="email" solo required></v-text-field>
                                    </v-col>
                                    <v-col cols="12" md="5">
                                        <v-text-field v-model="promocion.nombre" label="nombre" solo required></v-text-field>
                                    </v-col>                                    
                                    <v-col cols="12" md="1">
                                        <v-text-field v-model="promocion.estado" label="estado" solo required></v-text-field>
                                    </v-col>                                    
                                    <v-col cols="12" md="2">
                                        <v-text-field v-model="promocion.codigo" label="codigo" solo required></v-text-field>
                                    </v-col>                                        
                                </v-row>
                            </v-container>   
                            <v-card-text>
                                <v-card-actions>
                                    <v-spacer></v-spacer>
                                    <v-btn v-on:click="ocultarDialog">Cancelar</v-btn>
                                    <v-btn v-on:click="guardar">Guardar</v-btn>
                                </v-card-actions>
                            </v-card-text>
                    </v-form>
                    </v-card-text>
             
                </v-card>
            </v-dialog>

            <v-dialog v-model="generarCodigo" max-width="780">
                <v-card>
                    <v-card-title class="blue-grey darken-1 white--text">Generar Promocion</v-card-title>
                    <v-card-text>
                        <v-form>
                            <v-container>
                                <v-row>
                                    <v-col cols="12" md="5">
                                        email
                                    </v-col>
                                    <v-col cols="12" md="5">
                                        nombre
                                    </v-col>                                    
                                    <v-col cols="12" md="2">
                                        codigo
                                    </v-col>                                        
                                </v-row>                                
                                <v-row>
                                    <v-col cols="12" md="5">
                                        <v-text-field v-model="promocionNuevo.email" label="email" solo required ></v-text-field>
                                    </v-col>
                                    <v-col cols="12" md="5">
                                        <v-text-field v-model="promocionNuevo.nombre" label="nombre" solo required></v-text-field>
                                    </v-col>                                    
                                    <v-col cols="12" md="2">
                                        <v-text-field v-model="codigoPromocion" label="codigo" solo required readonly></v-text-field>
                                    </v-col>                                        
                                </v-row>
                                    <v-alert
                                        border="top" color="red lighten-2" dark
                                        v-model="alertaEmail"
                                    >
                                        El correo ya fue utilizado anteriormente.
                                    </v-alert>                             
                                <v-row>

                                </v-row>
                            </v-container>   
                            <v-card-text>
                                <v-card-actions>
                                    <v-spacer></v-spacer>
                                    <v-btn v-on:click="ocultarGenerarCodigo">Cancelar</v-btn>
                                    <v-btn v-on:click="guardar">Generar</v-btn>
                                </v-card-actions>
                            </v-card-text>
                    </v-form>
                    </v-card-text>
             
                </v-card>
            </v-dialog>

            <v-dialog v-model="canjearCodigo" max-width="500">
                <v-card>
                    <v-card-title class="blue-grey darken-1 white--text">Canjear Codigo</v-card-title>
                    <v-card-text>
                        <v-form>
                            <v-container>
                                <v-row>
                                    <v-col cols="12" md="12">
                                        Ingrese el codigo
                                    </v-col>                                        
                                </v-row>                                
                                <v-row>
                                    <v-col cols="12" md="12">
                                        <v-text-field v-model="codigoPromocion" label="codigo" solo required></v-text-field>
                                    </v-col>                                        
                                </v-row>
                                    <v-alert
                                        border="top" color="red lighten-2" dark
                                        v-model="alertaCanje_failed"
                                    >
                                        El codigo {{codigoPromocion}} ya fue canjeado.
                                    </v-alert>                             
                                <v-row>
                                </v-row>
                                    <v-alert
                                        border="top" color="green lighten-2" dark
                                        v-model="alertaCanje_exit"
                                    >
                                        Haz canjeado el codigo: {{codigoPromocion}} !.
                                    </v-alert>                             
                                <v-row>                                    

                                </v-row>
                            </v-container>   
                            <v-card-text>
                                <v-card-actions>
                                    <v-spacer></v-spacer>
                                    <v-btn v-on:click="ocultarCanjearCodigo">Cancelar</v-btn>
                                    <v-btn v-on:click="guardar">Canjear</v-btn>
                                </v-card-actions>
                            </v-card-text>
                    </v-form>
                    </v-card-text>
             
                </v-card>
            </v-dialog>

        </v-card>
    </v-main>
</template>

<script>

import axios from 'axios'
    const consulta = {id: null, nombre: null, email: null,codigo:null, estado:null};
    const promocionNuevo = {id: null, nombre: null, email: null,codigo:null, estado:null};

    const headers = { 
        // "Authorization": authorization,
        "Content-Type":"application/json",
        "Access-Control-Allow-Origin":"*",
        "Access-Control-Allow-Credentials":true,
        "Access-Control-Allow-Methods":"GET,PUT,POST,DELETE,PATCH,OPTIONS",
        "Accept": "*/*"
      };
    
    //Docker
    var urlBackend = "http://192.168.101.6:8070/";

    var url=urlBackend+"api/Promocion/GetAllAsync";
    var urlInsertar=urlBackend+"api/Promocion/InsertAsync";
    var urlEditar=urlBackend+"api/Promocion/UpdateAsync";
    var urlCanjear=urlBackend+"api/Promocion/CanjearCodigoAsync";
    var urlEliminar=urlBackend+"api/Promocion/DeleteAsync";
    var operacion;

export default {
    name: 'Promocion',

     data: () => ({
        promociones:[],
        dialog:false,
        generarCodigo:false,
        canjearCodigo:false,
        alertaCanje_failed:false,
        alertaCanje_exit:false,
        codigoPromocion:'',
        mensajeAlertaEmail:'',
        alertaEmail:false,
        operacion:'',
        promocion:{
                  id:null,
                  nombre:null,
                  email:null,
                  estado:null,
                  codigo:null
              },
        promocionNuevo:{
                  id:null,
                  nombre:null,
                  email:null,
                  estado:null,
                  codigo:null
              },              
        }),
    created(){
         this.consultar()
      },
    methods:{
          consultar:function(){
              axios.get(url, consulta, headers)
              .then(response =>{
                  this.promociones = response.data.data
              } )
          },
          crear:function(){
              operacion = 1;
              this.guardar(operacion, promocionNuevo);
          },
          nuevo:function(){
              this.promocionNuevo.email = "";
              this.promocionNuevo.nombre = "";
              this.promocionNuevo.codigo = "";
              this.alertaEmail = false;
              operacion = 1;
              this.generarCodigo = true;
          },
          canjear:function(){

              this.alertaEmail = false;
              this.canjearCodigo = true;
              this.codigoPromocion = "";
              this.alertaCanje_exit = false;
              this.alertaCanje_failed = false;              
              operacion = 3;
              
          },          
          guardar:function(){
              if (operacion == 3) {
                    this.promocion.codigo = this.codigoPromocion;
                    this.promocion.id = 0;
                    this.promocion.nombre = "";
                    this.promocion.email = "";
                    this.promocion.estado = 0;
                    axios.put(urlCanjear, this.promocion, { headers })
                    .then(response =>{
                        if (response.data.data)
                        {
                            this.alertaCanje_exit = true;
                            this.alertaCanje_failed = false;
                        } else {
                            this.alertaCanje_failed = true;
                            this.alertaCanje_exit = false;
                        }
                        this.consultar();
              });  
              } else if (operacion == 1) {
                  promocionNuevo.id = 0;
                  promocionNuevo.email = this.promocionNuevo.email;
                  promocionNuevo.nombre = this.promocionNuevo.nombre;
                  promocionNuevo.estado = 0;
                  promocionNuevo.codigo = "";
                  axios.post(urlInsertar, promocionNuevo, { headers })
                  .then(response =>{
                      var mensaje = response.data.message;
                      if(response.data.data)
                      {
                        this.codigoPromocion = mensaje;
                        this.alertaEmail = false;
                      } else{
                        this.alertaEmail = true;
                      }
                      this.consultar();
                });
              } else {
                  axios.put(urlEditar, this.promocion, { headers })
                  .then(() =>{
                    this.consultar();
                  this.promocion.email = "";
                  this.promocion.clave = "";
                  this.promocion.estado = "";
                  this.dialog = false;
              });      
              }
          },
          ocultarDialog:function(){
            this.dialog = false;
          },
          ocultarGenerarCodigo:function(){
            this.generarCodigo = false;
          },   
          ocultarCanjearCodigo:function(){
            this.canjearCodigo = false;
          },                 
          eliminar:function(id){
              axios.delete(urlEliminar + '/' + id, { headers })
              .then(() =>{
                  this.consultar();
              });
          },
          editar:function(id,nombre,email,codigo, estado){
              this.promocion.id = id;
              this.promocion.email = email;
              this.promocion.nombre = nombre;
              this.promocion.estado = estado;
              this.promocion.codigo = codigo;
              this.dialog = true;
              operacion = 2;
          },
      }
  }

</script>

<style>
</style>