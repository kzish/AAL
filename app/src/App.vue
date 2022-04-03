<template>
  <!-- <div id="nav">
    <router-link to="/">Home</router-link> |
    <router-link to="/about">About</router-link>
  </div> -->
  <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
      <div class="container">
          <a class="navbar-brand" href="#">Adeyemi Academy</a>
          <!-- <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation"><span class="navbar-toggler-icon"></span></button>
          <div class="collapse navbar-collapse" id="navbarSupportedContent">
              <ul class="navbar-nav ms-auto mb-2 mb-lg-0">
                  <li class="nav-item"><a class="nav-link active" aria-current="page" href="#">Home</a></li>
                  <li class="nav-item"><a class="nav-link" href="#">Link</a></li>
                  <li class="nav-item dropdown">
                      <a class="nav-link dropdown-toggle" id="navbarDropdown" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Dropdown</a>
                      <ul class="dropdown-menu dropdown-menu-end" aria-labelledby="navbarDropdown">
                          <li><a class="dropdown-item" href="#">Action</a></li>
                          <li><a class="dropdown-item" href="#">Another action</a></li>
                          <li><hr class="dropdown-divider" /></li>
                          <li><a class="dropdown-item" href="#">Something else here</a></li>
                      </ul>
                  </li>
              </ul>
          </div> -->


        <!-- not logged in -->
        <ul v-if="!appstore.is_logged_in" class="navbar-nav ms-auto mb-2 mb-lg-0">
            <div class="col-md-12 logged-out-sign-in-form">
                <label data-bs-toggle="modal" data-bs-target="#login_modal">Login</label> | <label>Register</label>
            </div>
            <!-- <i class="fa-solid fa-bars fa-bars-menu" data-bs-toggle="dropdown"></i>
            <ul class="dropdown-menu dropdown-menu-end" aria-labelledby="navbarDropdown">
                <div class="row">
                    <div class="col-md-12 logged-out-sign-in-form" data-bs-toggle="modal" data-bs-target="#login_modal">
                        <label>Login</label> | <label>Register</label>
                    </div>
                </div>
            </ul> -->
        </ul>
        <!-- logged in -->
        <div v-if="appstore.is_logged_in" class="collapse navbar-collapse">
            <ul class="navbar-nav ms-auto mb-2 mb-lg-0">   
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" id="navbarDropdown" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                    <img src="/assets/img/person_avatar.png" class="avatar" alt="Avatar"> 
                        {{appstore.getUser().email}}
                    </a>
                    <ul class="dropdown-menu dropdown-menu-end" aria-labelledby="navbarDropdown">
                        <!-- <li><a class="dropdown-item" href="#">Action</a></li>
                        <li><a class="dropdown-item" href="#">Another action</a></li> -->
                        <!-- <li><hr class="dropdown-divider" /></li> -->
                        <li><a class="dropdown-item" href="javascript:void(0)" @click="userLogout" >Logout</a></li>
                    </ul>
                </li>
            </ul>
        </div>

      </div>
   </nav>

 

    <!-- Login Modal -->
    <div class="modal fade" ref="login_modal" id="login_modal" data-bs-backdrop="true" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header modal-header-bg-img">
                    <!-- <h5 class="modal-title" id="staticBackdropLabel">Modal title</h5> -->
                    <!-- <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button> -->
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label>Email</label>
                                <input type="text" class="form-control" id="login_email" ref="login_email" data-bs-toggle="tooltip" data-bs-placement="top" title="Enter email" />
                            </div>
                            <div class="form-group">
                                <label>Password</label>
                                <input type="password" class="form-control" id="login_password" ref="login_password" data-toggle="tooltip" data-placement="top" title="Enter password"/>
                            </div>
                            <br/>
                            <div class="form-group">
                                <button type="submit" class="btn btn-success" @click="userLogin()">Login</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
  <router-view/>
  <notifications position="top center" />
</template>

<style scoped>

    .logged-out-sign-in-form {
        padding: 10px 20px;
        z-index: 9;
        color: white;
        cursor: pointer;
    }

    .fa-bars-menu {
        cursor:pointer;
        color:white;
        font-size:32px;
    }

    .modal-header-bg-img {
        background-image: url('./assets/_h_city_1.jpg');
        background-color: #cccccc;
        height: 200px;
        background-position: center;
    }

    #login_modal {
        box-shadow: 0px 0px 5px black;
    }

</style>

<script>
import { APPSTORE } from '@/stores/appstore'
window.$ = window.jQuery = require('jquery');

export default {
    name: 'App',
    components:{},
    setup() {
        const appstore = APPSTORE()

        return {
            appstore,
        }
    },
    data() {
    },
    computed: {},
    mounted() {
        //check if user is logged in
        let user = this.appstore.getUser();
        console.log('mounted: user', user);

    },
     methods: {
        
        userLogin() {
            if(this.$refs.login_email.value == "") {
                window.$("#login_email").tooltip('show');
            } else if(this.$refs.login_password.value == ""){
                window.$("#login_password").tooltip('show');
            }
            else {
                window.$("#login_email").tooltip('hide');
                window.$("#login_password").tooltip('hide');
                this.appstore.userLogin(this.$refs.login_email.value, this.$refs.login_password.value);
            }
        },

        userLogout() {
            this.appstore.userLogout();
        },
        
    },

}
</script>



