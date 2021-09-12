# Notes

## Microservies/components

* the defining characteristic of a microservice/component is autonomy
* components do not respond to questions

## Messages

### Commands

* requests to do something
* imperative

### Events

* records of things that have already happened
* past tense

### Structure

* id
* type
	* named for a business process in ubiquitous language
* data
	* payload
* metadata
	* for messaging infrastructure
	* traceId
	* userId

## Streams

* logically grouped messages
* usually represent an entity or a process
* within a stream, messages are stored in the order they were written

### Types
	* all:
		* all events
	* category:
		* identified by name
		* contains every event written to every entity stream in the category
		* components always subscribe to category streams
		* "characterCatalog"
	* entity:
		* identified by the entity id and category name
		* contains every event written for an entity
		* "characterCatalog-xxxx-xx-xxxxxx"
	* command:
		* identified by category name and command marker
		* "characterCatalog:command"

* stream boundaries ARE component boundaries
	* this is important for avoiding monoliths
	* only the Foo component can write to streams in the Foo category
	* only the Foo component can handle commands in the Foo category

* commands originate from users

# Questions

* should stream/component names be part of events?
	* question comes from the fact that you could identify a source category stream this way
	* leaning towards "no" because it may not be beneficil for any other reason, and I'm yet to encounter the situation where you would need to do the above

* does a category stream actually contain duplicate events or event references?

* is there anything that ties an event to a stream other than where it's placed?
