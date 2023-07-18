Feature: Workflow

Scenario: Get All Workflow Types
  When I send "GET" all Workflow types request for "<Version>"
  Then I validate request <StatusCode>
  And I validate response body has <Expected> result
  
  
Examples:
  | Version | StatusCode | Expected |
  | V1.0    | 200        | 10       |  
  | V1.0    | 200        | 14       |



Scenario: Get All Workflows
  When I send "GET" all workflows request for "<Version>" with query parameters
    | WorkflowRoleId   | SearchText   | PageSize   | Page   | SortColumn   | SortAscending   |
    | <WorkflowRoleId> | <SearchText> | <PageSize> | <Page> | <SortColumn> | <SortAscending> |
  Then I validate request <StatusCode>

  Examples:
  | WorkflowTypeIds | SearchText | PageSize | Page | SortColumn | SortAscending | Version | StatusCode | Expected |
  | 10              |            |          |      |            |               | V1.0    | 200        | 10       |
  | 10              |            |          |      |            |               | V1.0    | 200        | 14       |  

  Scenario: Submit coding for procedures in the order and the order after

  When I send "GET" all workflows request for "<Version>" with query parameters
    | WorkflowTypeIds   | PageSize | Page | SortColumn | SortAscending |
    | <WorkflowTypeIds> | 20       | 1    | startTime  | false         |
  Then I validate request <StatusCode>
  And I get all workflows for one order that have "Initial" stage and save ids
  When I send "GET" workflow by Id request for "<Version>" with Id as path parameter
  Then I validate request <StatusCode>
  And I get all actions, staged data, workflowName, currentStage
  When I send workflow "POST" request with action name Take Ownership for "<Version>" with payload parameters
  Then I validate request <StatusCode>
  When I send "GET" workflow by Id request for "<Version>" with Id as path parameter
  Then I validate request <StatusCode>
  And I get all actions, staged data, workflowName, currentStage
  When I send workflow "POST" request with action name "Submit"  "<Result>"  for "<Version>" with payload parameters
  Then I validate request <StatusCode>

  Examples:
  | WorkflowTypeIds | OrderWorkflowTypeIds | PageSize | Page | SortColumn | SortAscending | Result | Remarks | Version | StatusCode |
  | 14                  | 10                   | 20       | 1    | startTime  | false         | Yellow |         | V1.0    | 200        |