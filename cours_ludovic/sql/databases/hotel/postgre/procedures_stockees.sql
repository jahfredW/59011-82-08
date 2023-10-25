create or replace function format_date("date" date, separator varchar )
returns text 
language plpgsql
as  $$
begin 
	return to_char("date", 'DD' || separator || 'MM' || separator || 'YYYY');
end
$$

select format_date('2023-02-01', '/');

select format_date(o."date", '/') from "order" o 

create or replace function get_items_count()
returns integer
language plpgsql
as $$
declare 
	items_count integer;
	time_now time = now();

begin 
	select count(id) 
	into items_count 
	from item; 
	
	raise notice '% articles à %', items_count, time_now;

	return items_count;
end;
$$

select get_items_count()


create or replace function stock_alert()
returns integer
language plpgsql 
as $$ 
declare 
	items_count integer;
	time_now time = now();
begin 
	select count(id) 
	into items_count
	from item 
	where stock_alert > stock;
	
	raise notice '% article en alerte stock à %', items_count, time_now;
	
	return items_count;
end;
$$

select stock_alert()


-- faire un max sur un group by avec des sos requetes. 

select supplier_id 
	from "order" o 
	group by supplier_id 
	having count(*) = ( select max(order_count) from ( select o2.supplier_id, count(*) as order_count from "order" o2 group by o2.supplier_id  ) as subrequest) 

-- D'ou la fonction best supplier : 

create or replace function best_supplier()
returns text 
language plpgsql
as $$

declare best varchar;

begin
	select supplier_id 
	into best 
	from "order" o 
	group by supplier_id 
	having count(*) = ( select max(order_count) from ( select o2.supplier_id, count(*) as order_count from "order" o2 group by o2.supplier_id  ) as subrequest) ;
	
	
	raise notice 'le meilleur fournisseurs est %', best;
	
	return best;
end
$$



-- fonction satifaction string : 

create or replace function satisfaction_string_2(s_index int)
returns text 
language plpgsql 
as $$

declare satisfaction text;

begin
	if s_index < 1 then 
	raise notice ' sans commentaire';
	satisfaction = 'sans commentaire';
	elsif s_index < 3 then 
	raise notice ' mauvais ';
	satisfaction  = 'mauvais';
	elsif s_index < 5 then 
	raise notice ' passable ';
	satisfaction  = 'passable';
	elsif s_index < 7 then 
	raise notice ' moyen ';
	satisfaction  = 'moyen';
	elsif s_index < 9 then 
	raise notice ' bon ';
	satisfaction  = 'bon';
	elsif s_index < 11 then 
	raise notice ' excellent ';
	satisfaction  = 'excellent';
	else 
	raise notice ' indice incorrect ';
	satisfaction  = 'indice incorrect';
	end if;

	return satisfaction;
	
end

$$

select satisfaction_string_2(1)

select s.id , s."name",  satisfaction_string_2(s.satisfaction_index)  from supplier s


-- avec un case  : 

create or replace function satisfaction_string_case(s_index int)
returns text 
language plpgsql 
as $$

declare satisfaction text;

begin
	case 
		when s_index < 1 then satisfaction = 'sans commentaire';
		when s_index < 3 then satisfaction = 'mauvais';
		when s_index < 5 then satisfaction = 'passable';
		when s_index < 7 then satisfaction = 'moyen';
		when s_index < 9 then satisfaction = 'bon';
		when s_index < 11 then satisfaction = 'excellent';
		else satisfaction = 'valeur incorrecte';
	end case;

	return satisfaction;
	
end
$$