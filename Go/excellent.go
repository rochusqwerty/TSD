package main

import (
	"encoding/json"
	"log"
	"net/http"
	"strconv"

	"github.com/gorilla/mux"
)


type CarResource struct {
	Id string `json:"id"`
	Make string `json:"make"`
	Model string `json:"model"`
	Owner OwnerResource `json:"owner"`
}

type OwnerResource struct {
	Name string `json:"name"`
	Surname string `json:"surname"`
}

var resources []CarResource
var globalId = -1

func getNextId() int {
	globalId++
	return globalId
}

func getAllResources(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "application/json")
	json.NewEncoder(w).Encode(resources)
}

func getResourceByID(w http.ResponseWriter, r *http.Request) {
	vars := mux.Vars(r)
	w.Header().Set("Content-Type", "application/json")
	for _, item := range resources {
		if item.Id == vars["id"] {
			json.NewEncoder(w).Encode(item)
			return
		}
	}
	json.NewEncoder(w).Encode(&CarResource{})
}

func createResource(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "application/json")
	var newCar CarResource
	if r.Body == nil {
		http.Error(w, "Please send a request body", 400)
		return
	}
	err  := json.NewDecoder(r.Body).Decode(&newCar)
	newCar.Id = strconv.Itoa(getNextId())
	if err != nil {
		http.Error(w, err.Error(), 400)
		return
	}
	resources = append(resources, newCar)
	json.NewEncoder(w).Encode(&newCar)
}

func deleteResource(w http.ResponseWriter, r *http.Request) {
	vars := mux.Vars(r)
	var count = 0
	w.Header().Set("Content-Type", "application/json")
	for _, item := range resources {
		if item.Id == vars["id"] {
		  //resources = append(resources[:count], resources[count+1:]...)
		  copy(resources[count:], resources[count+1:])
		  resources[len(resources)-1] = CarResource{}
		  resources = resources[:len(resources)-1] 
		  break
		}
		count ++
	}
	json.NewEncoder(w).Encode(resources)
}

func updateResource(w http.ResponseWriter, r *http.Request) {
	vars := mux.Vars(r)
	var count = 0
	w.Header().Set("Content-Type", "application/json")
	for _, item := range resources {
		if item.Id == vars["id"] {
			//resources = append(resources[:count], resources[count+1:]...)
			copy(resources[count:], resources[count+1:])
			resources[len(resources)-1] = CarResource{}
			resources = resources[:len(resources)-1] 
			
			var newCar CarResource
			if r.Body == nil {
				http.Error(w, "Please send a request body", 400)
				return
			}
			err  := json.NewDecoder(r.Body).Decode(&newCar)
			newCar.Id = vars["id"]
			if err != nil {
				http.Error(w, err.Error(), 400)
				return
			}
			resources = append(resources, newCar)
			json.NewEncoder(w).Encode(&newCar)
			return
		}
		count ++
	}

	json.NewEncoder(w).Encode(resources)
}

// Main function
func main() {
	r := mux.NewRouter()

	var owner0 = OwnerResource{"John", "Doe"}
	var owner1 = OwnerResource{"Jim", "Idk"}

	resources = append(resources, CarResource{strconv.Itoa(getNextId()), "Suzuki", "Samurai", owner0})
	resources = append(resources, CarResource{strconv.Itoa(getNextId()), "Suzuki", "Jimny", owner0})
	resources = append(resources, CarResource{strconv.Itoa(getNextId()), "Suzuki", "Vitara", owner0})
	resources = append(resources, CarResource{strconv.Itoa(getNextId()), "Nissan", "Patrol", owner1})

	// registering endpoints
	r.HandleFunc("/goapi/carresources", getAllResources).Methods("GET")
	r.HandleFunc("/goapi/carresources/{id}", getResourceByID).Methods("GET")
	r.HandleFunc("/goapi/carresources", createResource).Methods("POST")
	r.HandleFunc("/goapi/carresources/{id}", deleteResource).Methods("POST")
	r.HandleFunc("/goapi/carresources/{id}", updateResource).Methods("PUT")

	// Starting the server at port 8000 with logging
	log.Fatal(http.ListenAndServe(":8000", r))
}